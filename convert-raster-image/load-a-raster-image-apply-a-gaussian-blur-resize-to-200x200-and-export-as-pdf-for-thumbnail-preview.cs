using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\Thumbnails\thumb.pdf";

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

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Resize to 200x200 pixels
                rasterImage.Resize(200, 200);

                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the processed image as PDF
                rasterImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}