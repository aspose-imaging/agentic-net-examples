using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for watermark removal
            RasterImage raster = (RasterImage)image;

            // Define mask region (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 100)));
            mask.AddFigure(figure);

            // Use Telea algorithm for watermark removal
            var options = new TeleaWatermarkOptions(mask);

            // Perform watermark removal
            using (RasterImage result = WatermarkRemover.PaintOver(raster, options))
            {
                // Save result as APNG, preserving original metadata
                var saveOptions = new ApngOptions { KeepMetadata = true };
                result.Save(outputPath, saveOptions);
            }
        }
    }
}