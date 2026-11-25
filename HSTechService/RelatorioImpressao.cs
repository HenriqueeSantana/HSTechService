using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;

namespace HSTechService
{
    public static class RelatorioImpressao
    {
        private static readonly CultureInfo PtBr = new("pt-BR");

        private class Estado
        {
            public int Indice;
            public int Pagina;
        }

        public static void Visualizar(IWin32Window? dono, RelatorioMensal relatorio)
        {
            try
            {
                var loja = LojaRepository.Carregar();
                using var logo = LogoHelper.CarregarDaLoja(loja);
                var estado = new Estado();

                using var documento = new PrintDocument { DocumentName = "Relatório " + relatorio.MesTexto };
                documento.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
                documento.BeginPrint += (s, e) =>
                {
                    estado.Indice = 0;
                    estado.Pagina = 0;
                };
                documento.PrintPage += (s, e) =>
                {
                    if (e.Graphics == null)
                        return;

                    e.HasMorePages = DesenharPagina(e.Graphics, e.MarginBounds, relatorio, loja, logo, estado);
                };

                using var visualizacao = new PrintPreviewDialog
                {
                    Document = documento,
                    UseAntiAlias = true,
                    ClientSize = new Size(1000, 720),
                    StartPosition = FormStartPosition.CenterParent,
                    Text = "Pré-visualização do relatório"
                };

                visualizacao.ShowDialog(dono);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível abrir a visualização de impressão. Verifique se há uma impressora instalada.\n\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool DesenharPagina(Graphics g, Rectangle area, RelatorioMensal rel,
            Loja loja, Image? logo, Estado estado)
        {
            estado.Pagina++;

            using var fTitulo = new Font("Segoe UI", 16F, FontStyle.Bold);
            using var fSubtitulo = new Font("Segoe UI", 11F, FontStyle.Bold);
            using var fSecao = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            using var fTexto = new Font("Segoe UI", 9.5F);
            using var fNegrito = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            using var fPequena = new Font("Segoe UI", 8F);
            using var preto = new SolidBrush(Color.Black);
            using var azul = new SolidBrush(Tema.Azul);
            using var branco = new SolidBrush(Color.White);
            using var cinza = new SolidBrush(Color.FromArgb(90, 90, 90));
            using var penAzul = new Pen(Tema.Azul, 2.5F);
            using var penCinza = new Pen(Color.FromArgb(200, 200, 200), 1F);
            using var direita = new StringFormat
            {
                Alignment = StringAlignment.Far,
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            };
            using var esquerda = new StringFormat
            {
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            };

            float x = area.Left;
            float largura = area.Width;
            float y = area.Top;

            void Secao(string titulo)
            {
                y += 6;
                g.DrawString(titulo, fSecao, azul, x, y);
                y += 22;
                g.DrawLine(penCinza, x, y, x + largura, y);
                y += 6;
            }

            void Rodape()
            {
                g.DrawString($"Emitido em {DateTime.Now:dd/MM/yyyy HH:mm}", fPequena, cinza, x, area.Bottom - 12);
                g.DrawString("Página " + estado.Pagina, fPequena, cinza,
                    new RectangleF(x, area.Bottom - 12, largura, 14), direita);
            }

            // Cabeçalho
            float xTexto = x;

            if (logo != null)
            {
                float escala = Math.Min(100F / logo.Width, 50F / logo.Height);
                float larguraLogo = logo.Width * escala;
                float alturaLogo = logo.Height * escala;

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(logo, x, y, larguraLogo, alturaLogo);
                xTexto = x + larguraLogo + 12;
            }

            g.DrawString(loja.Nome, fTitulo, azul,
                new RectangleF(xTexto, y, largura - (xTexto - x), 28), esquerda);
            g.DrawString("RELATÓRIO MENSAL  -  " + rel.MesTexto.ToUpper(PtBr), fSubtitulo, preto,
                new RectangleF(xTexto, y + 28, largura - (xTexto - x), 20), esquerda);

            y += 58;
            g.DrawLine(penAzul, x, y, x + largura, y);
            y += 8;

            if (estado.Pagina == 1)
            {
                Secao("RESUMO DO MÊS");

                var linhas = new (string Rotulo, string Valor)[]
                {
                    ("OS abertas no mês", rel.Abertas.ToString()),
                    ("OS entregues no mês", rel.Entregues.ToString()),
                    ("Faturamento (OS entregues)", "R$ " + rel.Faturamento.ToString("N2", PtBr)),
                    ("Valor médio por OS entregue", "R$ " + rel.TicketMedio.ToString("N2", PtBr))
                };

                foreach (var linha in linhas)
                {
                    g.DrawString(linha.Rotulo, fNegrito, preto, x, y);
                    g.DrawString(linha.Valor, fTexto, preto, x + 220, y);
                    y += 20;
                }

                Secao("OS ABERTAS NO MÊS, POR SITUAÇÃO ATUAL");

                if (rel.PorSituacao.Count == 0)
                {
                    g.DrawString("Nenhuma OS aberta neste mês.", fTexto, cinza, x, y);
                    y += 20;
                }

                foreach (var situacao in rel.PorSituacao)
                {
                    g.DrawString(situacao.Situacao, fNegrito, preto, x, y);
                    g.DrawString(situacao.Quantidade.ToString(), fTexto, preto, x + 220, y);
                    y += 20;
                }
            }

            Secao("OS ENTREGUES NO MÊS");

            if (rel.Entregas.Count == 0)
            {
                g.DrawString("Nenhuma OS entregue neste mês.", fTexto, cinza, x, y);
                Rodape();
                return false;
            }

            const float alturaLinha = 18F;
            float colOs = x + 4;
            float colEntrega = x + 62;
            float colCliente = x + 172;
            float colEquip = x + 322;
            float larguraCliente = colEquip - colCliente - 6;
            float larguraEquip = x + largura - 90 - colEquip - 6;

            // Cabeçalho da tabela
            g.FillRectangle(azul, x, y, largura, alturaLinha + 2);
            g.DrawString("OS", fNegrito, branco, colOs, y + 1);
            g.DrawString("Entrega", fNegrito, branco, colEntrega, y + 1);
            g.DrawString("Cliente", fNegrito, branco, colCliente, y + 1);
            g.DrawString("Equipamento", fNegrito, branco, colEquip, y + 1);
            g.DrawString("Valor", fNegrito, branco,
                new RectangleF(x, y + 1, largura - 4, alturaLinha), direita);
            y += alturaLinha + 4;

            while (estado.Indice < rel.Entregas.Count)
            {
                if (y + alturaLinha > area.Bottom - 45)
                {
                    Rodape();
                    return true;
                }

                var os = rel.Entregas[estado.Indice];

                g.DrawString(os.Numero, fTexto, preto, colOs, y);
                g.DrawString(os.DataEntregaFormatada, fTexto, preto, colEntrega, y);
                g.DrawString(os.ClienteNome, fTexto, preto,
                    new RectangleF(colCliente, y, larguraCliente, alturaLinha), esquerda);
                g.DrawString(os.EquipamentoResumo, fTexto, preto,
                    new RectangleF(colEquip, y, larguraEquip, alturaLinha), esquerda);
                g.DrawString("R$ " + os.Valor.ToString("N2", PtBr), fTexto, preto,
                    new RectangleF(x, y, largura - 4, alturaLinha), direita);

                y += alturaLinha;
                g.DrawLine(penCinza, x, y, x + largura, y);
                y += 2;
                estado.Indice++;
            }

            y += 6;
            g.DrawString($"Total: {rel.Entregues} OS entregues  |  R$ {rel.Faturamento.ToString("N2", PtBr)}",
                fNegrito, preto, new RectangleF(x, y, largura - 4, 20), direita);

            Rodape();
            return false;
        }
    }
}