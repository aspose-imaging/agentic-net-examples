using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"input\sample.bmp";
        string outputPath = @"output\result.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for raster operations
            RasterImage raster = (RasterImage)image;

            // Resize to 640x480
            raster.Resize(640, 480);

            // Apply a median filter with kernel size 5
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Save the processed image as PDF
            PdfOptions pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}