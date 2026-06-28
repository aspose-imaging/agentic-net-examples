using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output\\output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
                raster.Save(outputPath, options);
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
 * 1. When a developer needs to generate a multi‑page PNG report where each page shows a different motion‑blur effect to emphasize direction of movement in a series of screenshots.
 * 2. When an e‑learning platform wants to create animated step‑by‑step tutorials as a single multi‑page PNG file, applying a unique blur angle to each step to guide the learner’s focus.
 * 3. When a digital signage system prepares a multi‑page PNG advertisement and applies varying motion‑blur angles per page to simulate motion across the display sequence.
 * 4. When a scientific visualization tool exports time‑lapse microscopy images into a multi‑page PNG and uses different blur angles to highlight directional cell migration on each frame.
 * 5. When a game developer creates a sprite sheet stored as a multi‑page PNG and applies distinct motion‑blur angles to each sprite frame to achieve realistic motion effects during gameplay.
 */