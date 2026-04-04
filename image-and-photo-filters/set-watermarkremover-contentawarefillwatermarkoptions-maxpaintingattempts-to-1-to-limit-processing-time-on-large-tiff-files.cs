using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (var image = Image.Load(inputPath))
        {
            var tiffImage = (TiffImage)image;

            // Create a mask using GraphicsPath
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
            mask.AddFigure(figure);

            // Configure ContentAwareFillWatermarkOptions with MaxPaintingAttempts = 1
            var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
            {
                MaxPaintingAttempts = 1
            };

            // Apply watermark removal
            using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(tiffImage, options))
            {
                // Save the processed image
                result.Save(outputPath);
            }
        }
    }
}