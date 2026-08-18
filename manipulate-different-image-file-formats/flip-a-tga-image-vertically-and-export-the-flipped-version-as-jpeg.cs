// HOW-TO: How to Vertically Flip a TGA Image and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the TGA image, flip vertically, and save as JPEG
            using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
            {
                // Vertical flip
                tgaImage.RotateFlip(RotateFlipType.RotateNoneFlipY);

                // Save as JPEG using JpegOptions (format inferred from extension)
                tgaImage.Save(outputPath, new JpegOptions());
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
 * 1. When you need to correct upside‑down TGA textures from a legacy game engine before publishing them as JPEG thumbnails.
 * 2. When an automated pipeline must convert raw TGA screenshots into web‑friendly JPEGs with a vertical flip to match screen orientation.
 * 3. When a desktop application processes user‑uploaded TGA files and stores the flipped version as JPEG for faster preview loading.
 * 4. When migrating legacy assets, you may need to flip TGA logos vertically and save them as JPEGs for inclusion in marketing materials.
 * 5. When generating printable JPEGs from TGA artwork that requires a vertical flip to align with the printer’s coordinate system.
 */
