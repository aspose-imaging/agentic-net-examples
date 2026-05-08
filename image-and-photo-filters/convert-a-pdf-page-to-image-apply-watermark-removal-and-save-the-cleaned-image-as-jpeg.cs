using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.pdf";
        string outputPath = "Output/cleaned.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load PDF page as an image
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing
                RasterImage raster = (RasterImage)pdfImage;
                if (!raster.IsCached)
                    raster.CacheData();

                // Define a simple rectangular mask for watermark removal
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(10, 10, 200, 200)));
                mask.AddFigure(figure);

                // Create watermark removal options (Telea algorithm)
                var wmOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                // Apply watermark removal
                using (RasterImage cleaned = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, wmOptions))
                {
                    // Save the cleaned image as JPEG
                    cleaned.Save(outputPath, new JpegOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}