using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for raster operations
            RasterImage raster = (RasterImage)image;

            // Cache data for better performance (optional)
            if (!raster.IsCached)
                raster.CacheData();

            // Crop a 300x300 region from the top-left corner
            raster.Crop(new Rectangle(0, 0, 300, 300));

            // Apply a median filter with kernel size 3 to the entire image
            raster.Filter(raster.Bounds, new MedianFilterOptions(3));

            // Save the processed image as PDF
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}