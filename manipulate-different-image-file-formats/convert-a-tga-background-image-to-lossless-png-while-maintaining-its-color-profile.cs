// HOW-TO: Convert TGA Background Image to Lossless PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/background.tga";
            string outputPath = "Output/background.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    image.Save(outputPath, options);
                }
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
 * 1. When you need to replace legacy TGA textures with PNG files for a game engine that only supports PNG while keeping the original colors intact.
 * 2. When a graphics pipeline requires lossless conversion of background assets from TGA to PNG to reduce file size without sacrificing quality.
 * 3. When automating a build process that imports TGA artwork and outputs PNGs for web delivery, preserving the embedded color profile.
 * 4. When migrating a digital asset library from TGA to a more widely supported format, ensuring the background image remains unchanged in appearance.
 * 5. When writing a C# utility to batch‑convert TGA backgrounds to PNG for use in cross‑platform applications that rely on PNG’s lossless compression.
 */
