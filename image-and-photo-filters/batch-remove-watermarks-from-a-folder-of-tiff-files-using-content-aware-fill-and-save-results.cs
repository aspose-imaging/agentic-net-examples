using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = @"C:\Input\Tiffs";
            string outputFolder = @"C:\Output\Tiffs";

            var files = Directory.GetFiles(inputFolder, "*.tif");
            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + "_clean.tif");
                string outDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outDir))
                    Directory.CreateDirectory(outDir);

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    var mask = new GraphicsPath();
                    var figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(0, 0, image.Width, image.Height)));
                    mask.AddFigure(figure);

                    var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                    {
                        MaxPaintingAttempts = 4
                    };

                    using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(image, options))
                    {
                        result.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}