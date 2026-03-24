using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (PngImage image = (PngImage)Image.Load(inputPath))
        {
            // Cache data for better performance
            if (!image.IsCached)
                image.CacheData();

            // Adjust brightness (+50)
            image.AdjustBrightness(50);

            // Resize to 800x600 using default resampling
            image.Resize(800, 600);

            // Save as JPEG with default options
            var jpegOptions = new JpegOptions();
            image.Save(outputPath, jpegOptions);
        }
    }
}