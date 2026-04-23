using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        string outputDir = "Output";
        Directory.CreateDirectory(outputDir);

        List<Size> sizes = new List<Size>
        {
            new Size(200, 200),
            new Size(400, 300),
            new Size(800, 600)
        };

        foreach (var sz in sizes)
        {
            string outputPath = Path.Combine(outputDir, $"image_{sz.Width}x{sz.Height}.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            FileCreateSource src = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions { Source = src };

            using (BmpImage canvas = (BmpImage)Image.Create(options, sz.Width, sz.Height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);
                graphics.DrawEllipse(
                    new Pen(Color.Red, 2),
                    new Rectangle(0, 0, sz.Width, sz.Height));
                canvas.Save();
            }
        }
    }
}