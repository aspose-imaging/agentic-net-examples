using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "c:\\temp\\input.webp";
        string outputPath = "c:\\temp\\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WebPImage to access the Filter method
            WebPImage webpImage = (WebPImage)image;

            // Apply a motion blur (motion wiener) filter to the entire image
            var filterOptions = new MotionWienerFilterOptions(10, 1.0, 90.0);
            webpImage.Filter(webpImage.Bounds, filterOptions);

            // Save the processed image as PNG
            webpImage.Save(outputPath, new PngOptions());
        }
    }
}