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
        string inputPath = "input/input.jpg";
        string outputPath = "output/result.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x1024
                image.Resize(1024, 1024);

                // Apply sharpening filter if the image is a raster image
                if (image is RasterImage rasterImage)
                {
                    // Sharpen filter with kernel size 5 and sigma 4.0
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));
                }

                // Save the processed image as PDF
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}