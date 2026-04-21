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
            // Hard‑coded input and output file paths
            string inputPath = "C:\\temp\\source.jpg";
            string outputPath = "C:\\temp\\output.webp";

            // Verify that the source JPEG exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure WebP options: lossy compression, quality 75, alpha channel support is inherent to WebP
                var webpOptions = new WebPOptions
                {
                    Lossless = false,   // lossy compression
                    Quality = 75f       // quality level 75
                };

                // Save the image as WebP with the specified options
                image.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}