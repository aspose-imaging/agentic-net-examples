using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.gif";
        string outputPath = @"c:\temp\output.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image (could be animated)
        using (Image image = Image.Load(inputPath))
        {
            // Configure WebP options (lossy compression with medium quality)
            var webpOptions = new WebPOptions
            {
                Lossless = false,
                Quality = 75
            };

            // Save the first (active) frame of the GIF as a WebP image
            image.Save(outputPath, webpOptions);
        }
    }
}