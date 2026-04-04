using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputCafPath = "output_caf.jpg";
        string outputTeleaPath = "output_telea.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputCafPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputTeleaPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for watermark removal
            RasterImage raster = (RasterImage)image;

            // Define the mask region (ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 150)));
            mask.AddFigure(figure);

            // Content-Aware Fill removal with two attempts
            var cafOptions = new ContentAwareFillWatermarkOptions(mask)
            {
                MaxPaintingAttempts = 2
            };
            using (RasterImage cafResult = WatermarkRemover.PaintOver(raster, cafOptions))
            {
                cafResult.Save(outputCafPath);
            }

            // Telea algorithm removal
            var teleaOptions = new TeleaWatermarkOptions(mask);
            using (RasterImage teleaResult = WatermarkRemover.PaintOver(raster, teleaOptions))
            {
                teleaResult.Save(outputTeleaPath);
            }
        }
    }
}