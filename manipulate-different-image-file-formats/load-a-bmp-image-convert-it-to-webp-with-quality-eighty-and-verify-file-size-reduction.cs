using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\Images\\input.bmp";
        string outputPath = "C:\\Images\\output.webp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Set WebP conversion options (quality 80)
                var webpOptions = new WebPOptions
                {
                    Quality = 80f,
                    Lossless = false
                };

                // Save as WebP
                image.Save(outputPath, webpOptions);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long webpSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original BMP size: {originalSize} bytes");
            Console.WriteLine($"Converted WebP size: {webpSize} bytes");

            if (webpSize < originalSize)
                Console.WriteLine("File size reduced after conversion.");
            else
                Console.WriteLine("File size not reduced after conversion.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}