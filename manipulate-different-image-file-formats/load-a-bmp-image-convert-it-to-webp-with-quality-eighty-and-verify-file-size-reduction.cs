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
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\sample_converted.webp";

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
                // Save as WebP with quality 80
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

            if (webpSize < originalSize)
            {
                Console.WriteLine($"Success: WebP file size ({webpSize} bytes) is smaller than original BMP size ({originalSize} bytes).");
            }
            else
            {
                Console.WriteLine($"Warning: WebP file size ({webpSize} bytes) is not smaller than original BMP size ({originalSize} bytes).");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}