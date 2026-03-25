using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

public class Program
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
            // Cast to RasterImage for processing
            RasterImage raster = (RasterImage)image;
            if (!raster.IsCached) raster.CacheData();

            // Resize to 1200x800
            raster.Resize(1200, 800);

            // Apply median filter with size 5
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Save the processed image as PDF
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                raster.Save(outputPath, pdfOptions);
            }
        }
    }
}