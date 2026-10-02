// HOW-TO: Convert TGA Image to BMP with Alpha and Original Bit Depth in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tga";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                BmpOptions options = new BmpOptions();
                options.BitsPerPixel = image.BitsPerPixel;
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
 * 1. When a game developer needs to export textures stored as TGA files to BMP for a Windows‑only engine while keeping transparency.
 * 2. When a legacy desktop application only accepts BMP files but the source assets are high‑color TGA images with an alpha channel.
 * 3. When an automated build pipeline must batch‑convert TGA sprites to BMP without losing the original bit depth for accurate color reproduction.
 * 4. When a photo‑processing tool requires BMP output for compatibility with older libraries, yet the source TGA retains per‑pixel opacity.
 * 5. When a GIS system imports BMP raster data and you must preserve the original TGA bit depth and alpha information during conversion.
 */
