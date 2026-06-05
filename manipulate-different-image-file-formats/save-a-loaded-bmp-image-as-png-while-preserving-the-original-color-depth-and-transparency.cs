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
            string inputPath = "input.bmp";
            string outputPath = "output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PNG, preserving color depth and transparency
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
 * 1. When a developer needs to convert legacy BMP assets to PNG for web delivery while keeping the original color depth and any alpha channel intact.
 * 2. When an application must batch‑process scanned BMP files and store them as lossless PNGs to reduce file size without losing transparency information.
 * 3. When a game engine imports user‑provided BMP textures and the pipeline requires PNG format for GPU loading, preserving the exact palette and transparency.
 * 4. When a document‑generation service receives BMP logos and must embed them as PNG images in PDFs, ensuring the original colors and transparent background remain unchanged.
 * 5. When a Windows desktop utility updates old BMP icons to modern PNG icons for high‑DPI displays, needing to retain the original bit depth and alpha channel.
 */