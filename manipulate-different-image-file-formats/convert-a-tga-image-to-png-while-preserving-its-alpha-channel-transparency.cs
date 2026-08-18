// HOW-TO: Convert TGA Image to PNG with Alpha Transparency in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.tga";
        string outputPath = "output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string? outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Load the TGA image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Save the image as PNG, preserving alpha channel
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
 * 1. When you need to display game textures originally saved as TGA files on a web page that only supports PNG with transparent backgrounds.
 * 2. When migrating legacy assets from a graphics pipeline that uses TGA to a modern UI framework that requires PNG images with preserved alpha channels.
 * 3. When automating a batch conversion of TGA sprites for a mobile app, ensuring the transparency remains intact for proper rendering.
 * 4. When integrating third‑party TGA resources into a C# desktop application that only loads PNG files with alpha support.
 * 5. When preparing print‑ready assets by converting TGA logos to PNG while keeping their transparent margins for layout software.
 */
