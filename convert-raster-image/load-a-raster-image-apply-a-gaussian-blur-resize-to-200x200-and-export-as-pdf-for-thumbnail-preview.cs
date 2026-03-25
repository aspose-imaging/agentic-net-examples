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
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Thumbnails\sample_thumbnail.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply Gaussian blur, resize, and save as PDF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access raster-specific methods
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
            rasterImage.Filter(rasterImage.Bounds, blurOptions);

            // Resize to 200x200 pixels
            rasterImage.Resize(200, 200);

            // Save the processed image as a PDF thumbnail
            var pdfOptions = new PdfOptions(); // Default PDF options
            rasterImage.Save(outputPath, pdfOptions);
        }
    }
}