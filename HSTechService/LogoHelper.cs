using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace HSTechService
{
    public static class LogoHelper
    {
        private const string ArquivoMarca = "logo_hstechservice.png";

        // Logo do sistema HSTechService, que acompanha o programa.
        public static Image? CarregarMarca()
        {
            try
            {
                string caminho = Path.Combine(AppContext.BaseDirectory, ArquivoMarca);
                if (!File.Exists(caminho))
                    return null;

                using var fluxo = File.OpenRead(caminho);
                using var imagem = Image.FromStream(fluxo);
                return new Bitmap(imagem);
            }
            catch
            {
                return null;
            }
        }

        // Logo da loja: a escolhida pelo cliente ou, se não houver, a do sistema.
        public static Image? CarregarDaLoja(Loja loja)
        {
            return DeBase64(loja.LogoBase64) ?? CarregarMarca();
        }

        public static string ParaBase64(Image origem, int larguraMaxima)
        {
            int largura = origem.Width;
            int altura = origem.Height;

            if (largura > larguraMaxima)
            {
                altura = (int)Math.Round(altura * (double)larguraMaxima / largura);
                largura = larguraMaxima;
            }

            using var bitmap = new Bitmap(largura, altura, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(origem, 0, 0, largura, altura);
            }

            using var memoria = new MemoryStream();
            bitmap.Save(memoria, ImageFormat.Png);
            return Convert.ToBase64String(memoria.ToArray());
        }

        public static Image? DeBase64(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return null;

            try
            {
                using var memoria = new MemoryStream(Convert.FromBase64String(texto));
                using var imagem = Image.FromStream(memoria);
                return new Bitmap(imagem);
            }
            catch
            {
                return null;
            }
        }
    }
}