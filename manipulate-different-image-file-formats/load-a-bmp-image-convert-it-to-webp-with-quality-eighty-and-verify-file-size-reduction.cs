using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Save as WebP with quality 80 (lossy)
                var webpOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 80f
                };
                image.Save(outputPath, webpOptions);
            }

            // Verify file size reduction
            long originalSize = new FileInfo(inputPath).Length;
            long webpSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original BMP size: {originalSize} bytes");
            Console.WriteLine($"Converted WebP size: {webpSize} bytes");

            if (webpSize < originalSize)
            {
                Console.WriteLine("File size reduction verified.");
            }
            else
            {
                Console.WriteLine("No size reduction detected.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}