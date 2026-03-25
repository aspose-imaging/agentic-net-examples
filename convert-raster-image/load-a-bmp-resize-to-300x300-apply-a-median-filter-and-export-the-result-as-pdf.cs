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
        string inputPath = "input.bmp";
        string outputPath = "output\\result.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image, resize, apply median filter, and save as PDF
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Optional caching for performance
            if (!raster.IsCached)
                raster.CacheData();

            // Resize to 300x300
            raster.Resize(300, 300);

            // Apply median filter with size 5
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Save as PDF
            PdfOptions pdfOptions = new PdfOptions();
            raster.Save(outputPath, pdfOptions);
        }
    }
}