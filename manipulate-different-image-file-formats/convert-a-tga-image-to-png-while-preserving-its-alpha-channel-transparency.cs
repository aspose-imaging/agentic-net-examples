// HOW-TO: Convert TGA Image to PNG with Alpha Transparency in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\image.tga";
        string outputPath = "Output\\image.png";

        try
        {
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
 * 1. When you need to display legacy TGA textures in a modern web application that only supports PNG with transparent backgrounds.
 * 2. When converting game asset files from TGA to PNG while keeping the alpha channel for proper sprite blending.
 * 3. When preparing print‑ready graphics that originate as TGA files but must be delivered as PNGs with preserved transparency.
 * 4. When automating a batch process that migrates TGA icons to PNG format for use in a Windows desktop application.
 * 5. When integrating third‑party TGA images into a C# reporting tool that renders PNG images with alpha channels.
 */
