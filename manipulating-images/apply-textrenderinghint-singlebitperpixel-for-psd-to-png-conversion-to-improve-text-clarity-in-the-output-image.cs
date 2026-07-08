using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.psd";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options with SingleBitPerPixel text rendering hint
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                    }
                };

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert layered Photoshop PSD files to PNG while preserving crisp text for web thumbnails, they can use Aspose.Imaging with TextRenderingHint.SingleBitPerPixel.
 * 2. When an automated build pipeline must generate high‑contrast PNG previews of PSD assets for a design review system, applying the SingleBitPerPixel text rendering hint ensures clear typography.
 * 3. When a desktop application exports user‑edited PSD documents to PNG for printing, using C# and Aspose.Imaging with SingleBitPerPixel rendering prevents blurry fonts in the final image.
 * 4. When a cloud service processes uploaded PSD logos and creates PNG icons with sharp text for mobile app assets, setting TextRenderingHint.SingleBitPerPixel improves legibility.
 * 5. When a batch script converts a large collection of PSD files to PNG for archival, applying the SingleBitPerPixel text rendering hint guarantees that all embedded text remains legible.
 */