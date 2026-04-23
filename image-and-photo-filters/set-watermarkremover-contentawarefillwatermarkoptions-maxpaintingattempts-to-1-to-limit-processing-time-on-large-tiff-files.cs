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
        try
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

            // Ensure output directory exists (null‑safe)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load the image (BigTIFF or regular TIFF)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for watermark removal
                RasterImage raster = (RasterImage)image;

                // Define the mask region
                var mask = new GraphicsPath();
                var figure = new Figure();
                // Example ellipse mask; adjust coordinates as needed
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
                mask.AddFigure(figure);

                // Configure Content Aware Fill options with limited attempts
                var options = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 1
                };

                // Perform watermark removal
                using (RasterImage result = WatermarkRemover.PaintOver(raster, options))
                {
                    // Save the processed image
                    result.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}