using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/output.png";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        Source source = new FileCreateSource(outputPath, false);

        PngOptions pngOptions = new PngOptions
        {
            Source = source,
            BufferSizeHint = 30
        };

        int width = 2000;
        int height = 2000;

        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, width, height))
        {
            Graphics graphics = new Graphics(canvas);
            graphics.BeginUpdate();

            graphics.Clear(Color.LightSkyBlue);

            int step = 20;
            for (int x = 0; x < width; x += step)
            {
                graphics.DrawLine(new Pen(Color.Red, 1), x, 0, x, height);
            }
            for (int y = 0; y < height; y += step)
            {
                graphics.DrawLine(new Pen(Color.Green, 1), 0, y, width, y);
            }

            graphics.EndUpdate();

            canvas.Save();
        }
    }
}