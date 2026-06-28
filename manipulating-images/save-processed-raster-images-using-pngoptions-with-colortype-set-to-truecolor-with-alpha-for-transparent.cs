using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hard‑coded input and output file paths.
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image.
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with Truecolor with Alpha (supports transparency).
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    BitDepth = 8,                     // 8 bits per channel (standard)
                    CompressionLevel = 9,             // Maximum compression (optional)
                    Progressive = true                // Enable progressive loading (optional)
                };

                // Save the image as PNG using the configured options.
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime exception message without crashing.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer needs to convert legacy BMP assets to PNG files with full‑color and alpha transparency for use on responsive websites.
 * 2. When a desktop application generates charts or diagrams and must export them as high‑quality PNG images that preserve transparent backgrounds for overlaying on other UI elements.
 * 3. When an e‑commerce platform processes product photos and wants to save them as PNG with maximum compression and progressive loading to improve page load speed while keeping transparent backgrounds for product cut‑outs.
 * 4. When a game developer creates sprite sheets from source images and needs to save each sprite as a Truecolor‑with‑Alpha PNG so that the game engine can render semi‑transparent effects correctly.
 * 5. When an automated batch‑processing script migrates scanned documents from BMP to PNG, applying 8‑bit per channel Truecolor with alpha to retain any watermark transparency and reduce file size.
 */