using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPdfPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Load, process, and save the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for raster operations
            RasterImage raster = (RasterImage)image;

            // Cache data if not already cached
            if (!raster.IsCached)
                raster.CacheData();

            // Resize to 640x480
            raster.Resize(640, 480);

            // Apply median filter with size 5
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

            // Save the processed image as PDF
            PdfOptions pdfOptions = new PdfOptions();
            image.Save(outputPdfPath, pdfOptions);
        }
    }
}