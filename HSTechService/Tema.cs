namespace HSTechService
{
    public static class Tema
    {
        public static readonly Color Azul = Color.FromArgb(10, 25, 47);
        public static readonly Color AzulClaro = Color.FromArgb(25, 55, 100);
        public static readonly Color Destaque = Color.FromArgb(37, 99, 235);
        public static readonly Color DestaqueEscuro = Color.FromArgb(29, 78, 216);
        public static readonly Color AzulSuave = Color.FromArgb(219, 234, 254);
        public static readonly Color Fundo = Color.FromArgb(240, 242, 245);
        public static readonly Color Branco = Color.FromArgb(255, 255, 255);
        public static readonly Color Cinza = Color.FromArgb(156, 163, 175);
        public static readonly Color CinzaTexto = Color.FromArgb(107, 114, 128);
        public static readonly Color Texto = Color.FromArgb(30, 30, 30);
        public static readonly Color Perigo = Color.FromArgb(220, 38, 38);
        public static readonly Color PerigoEscuro = Color.FromArgb(185, 28, 28);

        public static void Aplicar(Control raiz)
        {
            raiz.BackColor = Fundo;
            AplicarFilhos(raiz);
        }

        private static void AplicarFilhos(Control pai)
        {
            foreach (Control c in pai.Controls)
            {
                switch (c)
                {
                    case Button b:
                        EstilizarBotao(b);
                        break;
                    case TextBox t:
                        t.BorderStyle = BorderStyle.FixedSingle;
                        t.BackColor = t.ReadOnly ? Color.FromArgb(229, 231, 235) : Branco;
                        t.ForeColor = Texto;
                        break;
                    case ComboBox cb:
                        cb.FlatStyle = FlatStyle.Flat;
                        cb.BackColor = Branco;
                        cb.ForeColor = Texto;
                        break;
                    case ListBox lb:
                        lb.BorderStyle = BorderStyle.FixedSingle;
                        lb.BackColor = Branco;
                        lb.ForeColor = Texto;
                        break;
                    case DataGridView g:
                        EstilizarGrade(g);
                        break;
                    case GroupBox gb:
                        gb.BackColor = Branco;
                        break;
                    case Label l:
                        EstilizarLabel(l);
                        break;
                }

                if (c.HasChildren)
                    AplicarFilhos(c);
            }
        }

        private static void EstilizarLabel(Label l)
        {
            if (l.ForeColor == SystemColors.ControlText && l.Font.Bold && l.Font.Size >= 13F)
                l.ForeColor = Azul;
        }

        private static void EstilizarBotao(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.Cursor = Cursors.Hand;
            b.UseVisualStyleBackColor = false;
            b.FlatAppearance.BorderSize = 1;
            b.EnabledChanged += (s, e) => AtualizarBotao(b);
            AtualizarBotao(b);
        }

        private static void AtualizarBotao(Button b)
        {
            bool secundario = b.Name is "btnNovo" or "btnLimpar" or "btnNovoCliente";
            bool perigo = b.Name == "btnExcluir";
            bool discreto = b.Name == "btnFechar";

            Color fundo, texto, borda, hover;

            if (!b.Enabled)
            {
                fundo = Color.FromArgb(229, 231, 235);
                texto = Cinza;
                borda = Cinza;
                hover = fundo;
            }
            else if (discreto)
            {
                fundo = Branco;
                texto = CinzaTexto;
                borda = Branco;
                hover = Fundo;
            }
            else if (secundario)
            {
                fundo = Branco;
                texto = Azul;
                borda = Cinza;
                hover = Color.FromArgb(235, 237, 241);
            }
            else if (perigo)
            {
                fundo = Perigo;
                texto = Branco;
                borda = Perigo;
                hover = PerigoEscuro;
            }
            else
            {
                fundo = Destaque;
                texto = Branco;
                borda = Destaque;
                hover = DestaqueEscuro;
            }

            b.BackColor = fundo;
            b.ForeColor = texto;
            b.FlatAppearance.BorderColor = borda;
            b.FlatAppearance.MouseOverBackColor = hover;
            b.FlatAppearance.MouseDownBackColor = hover;
        }

        private static void EstilizarGrade(DataGridView g)
        {
            g.EnableHeadersVisualStyles = false;
            g.BackgroundColor = Branco;
            g.BorderStyle = BorderStyle.None;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = Color.FromArgb(225, 228, 233);
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersDefaultCellStyle.BackColor = Azul;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Branco;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Azul;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            g.DefaultCellStyle.ForeColor = Texto;
            g.DefaultCellStyle.SelectionBackColor = AzulSuave;
            g.DefaultCellStyle.SelectionForeColor = Azul;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 248, 250);
            g.RowTemplate.Height = 28;
        }
    }
}