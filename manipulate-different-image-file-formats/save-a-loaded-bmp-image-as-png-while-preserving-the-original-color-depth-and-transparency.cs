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
            string inputPath = "input.bmp";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Save as PNG preserving original color depth and transparency
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
 * 1. When a developer needs to convert legacy BMP graphics to PNG for web delivery while keeping the original color depth and any alpha channel intact.
 * 2. When an application must export UI icons stored as BMP to PNG format without losing transparency for high‑DPI displays.
 * 3. When a batch image‑processing tool has to transform scanned BMP files into PNG to reduce storage size yet preserve the exact palette and transparent background.
 * 4. When a game engine requires assets in PNG format but the source art is provided as BMP, and the conversion must retain the original bit depth for accurate color rendering.
 * 5. When a mobile app workflow imports BMP textures and saves them as PNG to meet platform requirements while ensuring no loss of color fidelity or transparency.
 */