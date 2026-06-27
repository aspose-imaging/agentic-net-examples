using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\frame0.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image gifImage = Image.Load(inputPath))
            {
                // Configure WebP options for lossless compression
                var webpOptions = new WebPOptions
                {
                    Lossless = true,
                    Quality = 100f,
                    // Export only the first frame (index 0)
                    MultiPageOptions = new MultiPageOptions(new Aspose.Imaging.IntRange(0, 1))
                };

                // Save the selected frame as a WebP image
                gifImage.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract the first frame of an animated GIF and store it as a high‑quality, lossless WebP file for use on a website that only supports static WebP images.
 * 2. When optimizing image assets for a mobile app, a programmer can convert a specific GIF frame to a lossless WebP to reduce file size while preserving pixel‑perfect visual fidelity.
 * 3. When generating thumbnails from multi‑frame GIFs, a C# service can select a particular frame and save it as a WebP image with lossless compression for fast loading in a gallery view.
 * 4. When integrating legacy GIF icons into a modern UI, a developer can use Aspose.Imaging to convert the required frame to a lossless WebP to maintain transparency and color accuracy.
 * 5. When preparing assets for an e‑commerce platform that requires WebP images, a backend process can extract a chosen GIF frame and save it as a lossless WebP to meet the platform’s image specifications.
 */