using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.Shapes;

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

        // Ensure output directory exists (null-safe)
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load the image (BigTIFF or any supported format)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for watermark processing
                RasterImage raster = (RasterImage)image;

                // Create a mask using GraphicsPath
                var mask = new GraphicsPath();
                var figure = new Figure();
                // Example ellipse mask; adjust coordinates as needed
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
                mask.AddFigure(figure);

                // Configure ContentAwareFillWatermarkOptions with MaxPaintingAttempts = 1
                var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 1
                };

                // Perform watermark removal
                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options);

                // Save the processed image
                result.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}