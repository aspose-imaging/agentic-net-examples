using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = @"C:\temp\BmpBatch";
            Directory.CreateDirectory(outputDir);

            int width = 500;
            int height = 500;

            int ellipseWidth = 300;
            int ellipseHeight = 200;
            int ellipseX = (width - ellipseWidth) / 2;
            int ellipseY = (height - ellipseHeight) / 2;

            List<Aspose.Imaging.Color> colors = new List<Aspose.Imaging.Color>
            {
                Aspose.Imaging.Color.Red,
                Aspose.Imaging.Color.Green,
                Aspose.Imaging.Color.Blue,
                Aspose.Imaging.Color.Yellow,
                Aspose.Imaging.Color.Cyan,
                Aspose.Imaging.Color.Magenta
            };

            int index = 1;
            foreach (var bgColor in colors)
            {
                string outputPath = Path.Combine(outputDir, $"image_{index}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                FileCreateSource source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };

                using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(options, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    graphics.Clear(bgColor);
                    graphics.DrawEllipse(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), ellipseX, ellipseY, ellipseWidth, ellipseHeight);
                    canvas.Save();
                }

                index++;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}