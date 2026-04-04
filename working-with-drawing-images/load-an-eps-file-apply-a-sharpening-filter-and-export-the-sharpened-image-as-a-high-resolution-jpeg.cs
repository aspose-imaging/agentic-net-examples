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
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\sample_sharpened.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image, apply sharpening filter, and save as high‑resolution JPEG
        using (var image = (RasterImage)Image.Load(inputPath))
        {
            // Apply sharpen filter to the whole image
            image.Filter(image.Bounds, new SharpenFilterOptions(5, 4.0));

            // Configure JPEG options for high quality
            var jpegOptions = new JpegOptions
            {
                Quality = 100
            };

            // Save the processed image
            image.Save(outputPath, jpegOptions);
        }
    }
}