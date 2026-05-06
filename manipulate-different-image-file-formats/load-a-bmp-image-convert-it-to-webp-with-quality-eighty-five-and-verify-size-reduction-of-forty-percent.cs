using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
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
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Configure WebP options with quality 85 (lossy)
                var webpOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 85f
                };

                // Save as WebP
                bmpImage.Save(outputPath, webpOptions);
            }

            // Verify size reduction of at least 40%
            long inputSize = new FileInfo(inputPath).Length;
            long outputSize = new FileInfo(outputPath).Length;

            if (outputSize <= inputSize * 0.6)
            {
                Console.WriteLine("Size reduction verified: output is at least 40% smaller.");
            }
            else
            {
                Console.WriteLine("Size reduction not sufficient.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}