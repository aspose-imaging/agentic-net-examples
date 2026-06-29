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
            string inputPath = "input.tga";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Save as PNG, preserving alpha channel
                image.Save(outputPath, new PngOptions());
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
 * 1. When a game developer needs to convert legacy TGA textures with alpha transparency into PNG files for modern game engines that only accept PNG assets.
 * 2. When a web designer must batch‑process TGA logos containing an alpha channel into PNG format to embed them in HTML pages without losing transparency.
 * 3. When an e‑learning platform imports user‑uploaded TGA screenshots and converts them to PNG to store them in a cloud‑based image repository while preserving the transparent background.
 * 4. When a digital artist exports TGA layers from Photoshop and uses C# with Aspose.Imaging to generate PNG previews for quick sharing on social media.
 * 5. When a GIS application reads TGA raster maps and saves them as PNG tiles, ensuring the alpha channel remains intact for overlaying on other map layers.
 */