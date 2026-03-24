using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output\\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        int width = 800;
        int height = 200;

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(bmpOptions, width, height))
        {
            Graphics graphics = new Graphics(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.Clear(Color.White);

            string text = "Hello, 世界 🌍";
            Font font = new Font("Arial", 48);

            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.Black;
                brush.Opacity = 100;
                graphics.DrawString(text, font, brush, 50f, 80f);
            }

            // Save the image (bound to the file)
            image.Save();
        }
    }
}