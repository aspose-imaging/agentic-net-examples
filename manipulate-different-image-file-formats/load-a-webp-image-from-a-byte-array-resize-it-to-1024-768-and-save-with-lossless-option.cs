using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output\\resized.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load WebP image from byte array
        byte[] imageData = File.ReadAllBytes(inputPath);
        using (var memoryStream = new MemoryStream(imageData))
        using (WebPImage webpImage = new WebPImage(memoryStream))
        {
            // Resize to 1024x768 using nearest neighbour resampling
            webpImage.Resize(1024, 768, ResizeType.NearestNeighbourResample);

            // Set lossless option
            var options = new WebPOptions
            {
                Lossless = true
            };

            // Save the resized image
            webpImage.Save(outputPath, options);
        }
    }
}