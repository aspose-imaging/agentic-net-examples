using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            using (BigTiffImage image = (BigTiffImage)Image.Load(inputPath))
            {
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
                mask.AddFigure(figure);

                var options = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 1
                };

                var result = WatermarkRemover.PaintOver(image, options);
                result.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}