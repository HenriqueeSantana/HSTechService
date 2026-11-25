namespace HSTechService
{
    public class TemaMenuRenderer : ToolStripProfessionalRenderer
    {
        public TemaMenuRenderer() : base(new TemaMenuCores())
        {
            RoundedEdges = false;
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.ToolStrip is MenuStrip || e.ToolStrip is ToolStripDropDown)
            {
                e.TextColor = e.Item.Enabled ? Color.White : Color.FromArgb(120, 135, 160);
            }

            base.OnRenderItemText(e);
        }
    }

    public class TemaMenuCores : ProfessionalColorTable
    {
        private static readonly Color Fundo = Color.FromArgb(15, 35, 65);
        private static readonly Color Linha = Color.FromArgb(45, 75, 125);

        public override Color MenuStripGradientBegin => Tema.Azul;
        public override Color MenuStripGradientEnd => Tema.Azul;
        public override Color ToolStripBorder => Tema.Azul;

        public override Color MenuItemSelected => Tema.AzulClaro;
        public override Color MenuItemSelectedGradientBegin => Tema.AzulClaro;
        public override Color MenuItemSelectedGradientEnd => Tema.AzulClaro;
        public override Color MenuItemBorder => Tema.AzulClaro;

        public override Color MenuItemPressedGradientBegin => Fundo;
        public override Color MenuItemPressedGradientMiddle => Fundo;
        public override Color MenuItemPressedGradientEnd => Fundo;

        public override Color MenuBorder => Linha;
        public override Color ToolStripDropDownBackground => Fundo;

        public override Color ImageMarginGradientBegin => Fundo;
        public override Color ImageMarginGradientMiddle => Fundo;
        public override Color ImageMarginGradientEnd => Fundo;

        public override Color SeparatorDark => Linha;
        public override Color SeparatorLight => Linha;
    }
}