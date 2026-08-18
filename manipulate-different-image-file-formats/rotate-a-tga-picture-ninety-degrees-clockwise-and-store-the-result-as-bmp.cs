// HOW-TO: Rotate TGA Image 90 Degrees Clockwise and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"input\sample.tga";
            string outputPath = @"output\rotated.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TgaImage for access to TGA-specific members if needed
                TgaImage tgaImage = image as TgaImage;
                if (tgaImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a TGA image.");
                    return;
                }

                // Rotate 90 degrees clockwise without resizing the canvas
                tgaImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save as BMP (format inferred from .bmp extension)
                tgaImage.Save(outputPath);
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
 * 1. When you need to display a legacy TGA sprite in a Windows application that only supports BMP, you can rotate it and convert it on the fly.
 * 2. When preparing game assets for a platform that requires BMP orientation, rotating the TGA by 90° clockwise ensures correct alignment.
 * 3. When batch‑processing scanned textures stored as TGA files to match a portrait layout, this code rotates each image before saving as BMP.
 * 4. When integrating legacy graphics into a .NET reporting tool that only accepts BMP, you can re‑orient the TGA without losing quality.
 * 5. When automating a pipeline that receives TGA screenshots from a device and must store them as BMP thumbnails with a specific orientation.
 */
