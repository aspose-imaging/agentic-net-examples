// HOW-TO: Convert OTG Image to 32‑Bit BMP with Alpha Channel in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.otg";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Ensure the image is a RasterImage for processing
                using (RasterImage rasterImage = (RasterImage)image)
                {
                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 32 // Preserve alpha channel
                    };
                    rasterImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to display an OTG vector graphic in a Windows application that only supports BMP files, preserving its transparency.
 * 2. When converting legacy OTG assets for a game engine that requires 32‑bit BMP textures with an alpha channel.
 * 3. When preparing printable images from OTG files while keeping transparent regions intact for overlay in publishing software.
 * 4. When migrating design assets from an OTG format to BMP for compatibility with older image processing tools that cannot read OTG.
 * 5. When automating a batch process that extracts OTG icons and saves them as BMP files with full transparency for UI themes.
 */
