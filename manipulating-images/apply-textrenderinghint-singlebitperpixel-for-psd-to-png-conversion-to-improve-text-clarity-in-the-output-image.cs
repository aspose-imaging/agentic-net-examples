using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
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

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with SingleBitPerPixel text rendering hint
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                    }
                };

                // Save as PNG
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
 * 1. When a designer exports a Photoshop PSD file containing vector text and the developer must generate a PNG thumbnail with crisp, legible characters for a web gallery, they can use this code with TextRenderingHint.SingleBitPerPixel.
 * 2. When an e‑learning platform needs to convert PSD lesson slides that include small annotation text into PNG images for mobile devices, applying SingleBitPerPixel ensures the text remains sharp after rasterization.
 * 3. When a print‑to‑screen preview tool processes PSD files with embedded fonts and wants to produce high‑contrast PNG previews without anti‑aliasing artifacts, the code sets the appropriate text rendering hint.
 * 4. When an automated build pipeline creates PNG assets from PSD source files for a game UI and the text must stay pixel‑perfect for pixel‑art style fonts, developers can employ this conversion method.
 * 5. When a document management system archives PSD documents as PNGs for quick indexing and needs the embedded text to be readable in low‑resolution thumbnails, using TextRenderingHint.SingleBitPerPixel in the save options achieves that.
 */