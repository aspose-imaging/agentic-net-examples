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
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\result.pdf";

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
            // Resize to 1024x1024
            image.Resize(1024, 1024);

            // Apply sharpening filter if the image is raster
            if (image is RasterImage rasterImage)
            {
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));
            }

            // Save as PDF
            var pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}