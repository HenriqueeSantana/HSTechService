using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;

namespace HSTechService
{
    public static class OsImpressao
    {
        private static readonly CultureInfo PtBr = new("pt-BR");

        private static readonly string[] Termos =
        {
            "1. O equipamento e os acessórios descritos acima foram conferidos na presença do cliente no momento da entrada.",
            "2. Nenhum serviço que gere custo será executado sem a aprovação prévia do cliente.",
            "3. A assistência não se responsabiliza por dados armazenados no equipamento. Recomenda-se a realização de backup antes da entrega.",
            "4. O equipamento deve ser retirado em até 90 dias após o aviso de conclusão do serviço.",
            "5. Para a retirada do equipamento é obrigatória a apresentação deste comprovante."
        };

        public static void Visualizar(IWin32Window? dono, OrdemServico os)
        {
            try
            {
                var loja = LojaRepository.Carregar();
                using var logo = LogoHelper.CarregarDaLoja(loja);

                using var documento = new PrintDocument { DocumentName = "OS " + os.Numero };
                documento.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
                documento.PrintPage += (s, e) =>
                {
                    if (e.Graphics == null)
                        return;

                    Desenhar(e.Graphics, e.MarginBounds, os, loja, logo);
                    e.HasMorePages = false;
                };

                using var visualizacao = new PrintPreviewDialog
                {
                    Document = documento,
                    UseAntiAlias = true,
                    ClientSize = new Size(1000, 720),
                    StartPosition = FormStartPosition.CenterParent,
                    Text = "Pré-visualização da OS " + os.Numero
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

        public static void Desenhar(Graphics g, Rectangle area, OrdemServico os, Loja? loja = null, Image? logo = null)
        {
            loja ??= LojaRepository.Carregar();

            Image? logoProprio = null;
            if (logo == null)
            {
                logoProprio = LogoHelper.CarregarDaLoja(loja);
                logo = logoProprio;
            }

            try
            {
                DesenharDocumento(g, area, os, loja, logo);
            }
            finally
            {
                logoProprio?.Dispose();
            }
        }

        private static void DesenharDocumento(Graphics g, Rectangle area, OrdemServico os, Loja loja, Image? logo)
        {
            using var fTitulo = new Font("Segoe UI", 18F, FontStyle.Bold);
            using var fOs = new Font("Segoe UI", 14F, FontStyle.Bold);
            using var fSecao = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            using var fTexto = new Font("Segoe UI", 9.5F);
            using var fNegrito = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            using var fPequena = new Font("Segoe UI", 8F);
            using var preto = new SolidBrush(Color.Black);
            using var azul = new SolidBrush(Tema.Azul);
            using var cinza = new SolidBrush(Color.FromArgb(90, 90, 90));
            using var penAzul = new Pen(Tema.Azul, 2.5F);
            using var penCinza = new Pen(Color.FromArgb(170, 170, 170), 1F);
            using var direita = new StringFormat { Alignment = StringAlignment.Far };
            using var esquerdaCortada = new StringFormat
            {
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            };
            using var centro = new StringFormat
            {
                Alignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            };

            float x = area.Left;
            float largura = area.Width;
            float y = area.Top;

            void Secao(string titulo)
            {
                y += 8;
                g.DrawString(titulo, fSecao, azul, x, y);
                y += 22;
                g.DrawLine(penCinza, x, y, x + largura, y);
                y += 6;
            }

            void Campo(string rotulo, string valor)
            {
                if (string.IsNullOrWhiteSpace(valor))
                    return;

                const float colunaRotulo = 130F;
                float larguraValor = largura - colunaRotulo;
                float altura = Math.Max(g.MeasureString(valor, fTexto, (int)larguraValor).Height, fTexto.GetHeight(g));

                g.DrawString(rotulo, fNegrito, preto, x, y);
                g.DrawString(valor, fTexto, preto, new RectangleF(x + colunaRotulo, y, larguraValor, altura + 2));
                y += altura + 3;
            }

            void Paragrafo(string texto, Font fonte, Brush pincel)
            {
                float altura = g.MeasureString(texto, fonte, (int)largura).Height;
                g.DrawString(texto, fonte, pincel, new RectangleF(x, y, largura, altura + 2));
                y += altura + 4;
            }

            // Cabeçalho: logo + dados da loja à esquerda, número da OS à direita
            var partes = new List<string>();
            if (loja.Cnpj.Length > 0) partes.Add("CNPJ: " + loja.Cnpj);
            if (loja.Telefone.Length > 0) partes.Add("Tel: " + loja.Telefone);
            if (loja.WhatsApp.Length > 0) partes.Add("WhatsApp: " + loja.WhatsApp);
            if (loja.Email.Length > 0) partes.Add(loja.Email);

            var linhasContato = new List<string>();
            if (partes.Count > 0) linhasContato.Add(string.Join("  |  ", partes));
            if (loja.Endereco.Length > 0) linhasContato.Add(loja.Endereco);

            float xTexto = x;

            if (logo != null)
            {
                const float maxLargura = 120F;
                const float maxAltura = 64F;
                float escala = Math.Min(maxLargura / logo.Width, maxAltura / logo.Height);
                float larguraLogo = logo.Width * escala;
                float alturaLogo = logo.Height * escala;

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(logo, x, y + (maxAltura - alturaLogo) / 2, larguraLogo, alturaLogo);
                xTexto = x + larguraLogo + 14;
            }

            float larguraNome = Math.Max(largura - (xTexto - x) - 285, 120);
            g.DrawString(loja.Nome, fTitulo, azul, new RectangleF(xTexto, y, larguraNome, 30), esquerdaCortada);

            if (loja.Subtitulo.Length > 0)
                g.DrawString(loja.Subtitulo, fTexto, cinza, new RectangleF(xTexto, y + 30, larguraNome + 100, 18), esquerdaCortada);

            g.DrawString("ORDEM DE SERVIÇO Nº " + os.Numero, fOs, preto, new RectangleF(x, y, largura, 26), direita);
            g.DrawString("Entrada: " + os.DataEntradaFormatada, fTexto, cinza, new RectangleF(x, y + 28, largura, 18), direita);

            float yContato = y + 52;
            foreach (string linha in linhasContato)
            {
                g.DrawString(linha, fPequena, cinza,
                    new RectangleF(xTexto, yContato, largura - (xTexto - x), 16), esquerdaCortada);
                yContato += 14;
            }

            float alturaCabecalho = Math.Max(54 + linhasContato.Count * 14, logo != null ? 70 : 0);
            y += alturaCabecalho + 4;
            g.DrawLine(penAzul, x, y, x + largura, y);
            y += 6;

            // Cliente
            Secao("DADOS DO CLIENTE");
            Campo("Nome", os.ClienteNome);
            Campo("CPF/CNPJ", os.CpfCnpj);
            Campo("Telefone", os.Telefone);
            Campo("WhatsApp", os.WhatsApp);
            Campo("Endereço", os.EnderecoCompleto);

            // Equipamento
            Secao("EQUIPAMENTO");
            Campo("Equipamento", os.EquipamentoResumo);
            Campo("Nº de série", os.NumeroSerie);
            Campo("Senha", os.Senha);
            Campo("Processador", os.Processador);
            Campo("Memória RAM", os.Memoria);
            Campo("Armazenamento", os.Armazenamento);
            Campo("Acessórios", os.Acessorios);
            Campo("Observações", os.Observacoes);

            // Defeito
            Secao("DEFEITO RELATADO");
            Paragrafo(os.DefeitoRelatado, fTexto, preto);

            // Laudo e valor (quando já houver)
            if (os.Laudo.Length > 0)
            {
                Secao("LAUDO TÉCNICO");
                Paragrafo(os.Laudo, fTexto, preto);
            }

            if (os.Valor > 0)
            {
                Secao("VALOR");
                Campo("Valor do serviço", "R$ " + os.Valor.ToString("N2", PtBr));
            }

            // Termos
            Secao("TERMOS DO ATENDIMENTO");
            foreach (string termo in Termos)
                Paragrafo(termo, fPequena, cinza);

            // Assinaturas
            float meio = largura / 2;
            float linhaAssinatura = Math.Min(Math.Max(y + 45, area.Bottom - 105), area.Bottom - 55);

            g.DrawLine(penCinza, x + 10, linhaAssinatura, x + meio - 20, linhaAssinatura);
            g.DrawLine(penCinza, x + meio + 20, linhaAssinatura, x + largura - 10, linhaAssinatura);

            g.DrawString("Assinatura do cliente", fPequena, cinza,
                new RectangleF(x + 10, linhaAssinatura + 4, meio - 30, 16), centro);
            g.DrawString(os.ClienteNome, fPequena, cinza,
                new RectangleF(x + 10, linhaAssinatura + 18, meio - 30, 16), centro);
            g.DrawString("Responsável técnico", fPequena, cinza,
                new RectangleF(x + meio + 20, linhaAssinatura + 4, meio - 30, 16), centro);

            g.DrawString($"Documento emitido em {DateTime.Now:dd/MM/yyyy HH:mm}", fPequena, cinza,
                x, area.Bottom - 12);
        }
    }
}