using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\scanned_document.png";
        string outputPath = @"C:\Images\output\cleaned_document.tif";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the scanned document image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for watermark removal
                RasterImage raster = (RasterImage)image;

                // Define the area of the text watermark to remove (example rectangle)
                var mask = new GraphicsPath();
                var figure = new Figure();
                // Adjust the rectangle coordinates to match the watermark location
                figure.AddShape(new RectangleShape(new RectangleF(100f, 200f, 400f, 100f)));
                mask.AddFigure(figure);

                // Configure Telea algorithm options with the mask
                var options = new TeleaWatermarkOptions(mask);

                // Remove the watermark
                RasterImage result = WatermarkRemover.PaintOver(raster, options);

                // Save the cleaned image as high‑resolution TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                result.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}