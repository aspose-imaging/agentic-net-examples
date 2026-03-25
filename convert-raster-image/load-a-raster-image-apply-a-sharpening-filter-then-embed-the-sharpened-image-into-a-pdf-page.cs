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
        string inputPath = @"C:\Temp\sample.png";
        string outputPath = @"C:\Temp\SharpenedOutput.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image, apply sharpening, and save as PDF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter (kernel size 5, sigma 4.0) to the whole image
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Prepare PDF save options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the sharpened image into a PDF file
            rasterImage.Save(outputPath, pdfOptions);
        }
    }
}