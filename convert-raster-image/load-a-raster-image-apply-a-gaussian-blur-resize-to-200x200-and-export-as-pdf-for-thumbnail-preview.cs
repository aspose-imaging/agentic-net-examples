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

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access raster operations
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Resize to 200x200 pixels (default NearestNeighbourResample)
            raster.Resize(200, 200);

            // Prepare PDF save options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the processed image as PDF
            raster.Save(outputPath, pdfOptions);
        }
    }
}