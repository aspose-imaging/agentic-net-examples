// HOW-TO: Resize PNG to 256x256 Using Nearest Neighbor and Embed Secure Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            string password = "SecurePassword123";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached)
                        image.CacheData();

                    image.Resize(256, 256, ResizeType.NearestNeighbourResample);
                    image.EmbedDigitalSignature(password);

                    var saveOptions = new PngOptions();
                    image.Save(outputPath, saveOptions);
                }
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
 * 1. When you need to batch‑process user‑uploaded PNG avatars to a fixed 256×256 size for a web portal while preserving sharp edges with nearest‑neighbor scaling.
 * 2. When you must protect PNG assets by embedding a digital signature protected by a password before distributing them to clients.
 * 3. When an e‑commerce platform requires all product PNG images to be uniformly sized and tamper‑evident for catalog uploads.
 * 4. When a mobile app stores thumbnail PNGs locally and you want to ensure each thumbnail is resized quickly and signed to prevent unauthorized modifications.
 * 5. When a document management system archives PNG scans and needs to standardize dimensions and add a secure signature for compliance auditing.
 */
