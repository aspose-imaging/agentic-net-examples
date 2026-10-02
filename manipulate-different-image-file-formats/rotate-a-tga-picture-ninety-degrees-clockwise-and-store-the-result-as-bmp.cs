// HOW-TO: Rotate TGA Image 90 Degrees Clockwise and Save as BMP in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.tga";
            string outputPath = "Output/result.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                BmpOptions options = new BmpOptions();
                image.Save(outputPath, options);
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
 * 1. When a game developer needs to re‑orient legacy TGA sprite sheets for a new engine and store them as BMP files for compatibility.
 * 2. When an automated build pipeline must convert TGA textures to BMP after rotating them to match the target device’s portrait orientation.
 * 3. When a desktop application processes user‑uploaded TGA screenshots, rotates them 90° clockwise, and saves them as BMP for faster loading.
 * 4. When a batch‑processing tool prepares TGA assets for printing by rotating them correctly and converting to BMP, which printers accept.
 * 5. When a migration script updates legacy graphics by rotating TGA icons and saving them as BMP to integrate with a Windows‑only UI framework.
 */
