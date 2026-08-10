// HOW-TO: Flip a GIF Horizontally in C# Using Aspose.Imaging RotateFlip (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.gif";
        string outputPath = @"C:\Images\output_flipped.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image, flip it horizontally, and save
            using (GifImage image = (GifImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                image.Save(outputPath);
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
 * 1. When you need to mirror an animated GIF for a website banner without losing its animation frames.
 * 2. When you want to create a left‑to‑right mirrored version of a product demo GIF for localization purposes.
 * 3. When you must generate a flipped GIF to match a UI layout that uses right‑to‑left reading direction.
 * 4. When you are preprocessing GIF assets for a game and require horizontal flipping before packaging.
 * 5. When you need to programmatically correct the orientation of uploaded GIFs that were captured reversed horizontally.
 */
