// HOW-TO: Flip GIF Image Horizontally With RotateFlipType In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output_flipped.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
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
 * 1. When you need to mirror an animated GIF for a web banner using Aspose.Imaging’s RotateFlip method in C#.
 * 2. When you want to create a left‑to‑right transition effect by flipping each frame of a GIF before displaying it in a .NET UI.
 * 3. When you must generate a mirrored version of a user‑uploaded GIF for a photo‑editing app without altering the original file, using C# code.
 * 4. When you are preprocessing GIF assets for a game and need the sprites to face the opposite direction by applying RotateNoneFlipX.
 * 5. When you have to correct the orientation of a GIF that was captured upside‑down by flipping it horizontally during batch processing with Aspose.Imaging.
 */
