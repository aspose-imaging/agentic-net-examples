using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
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
                if (!image.IsCached)
                    image.CacheData();

                // Rotate 45 degrees, resize canvas proportionally, fill background with transparent color
                image.Rotate(45f, true, Color.FromArgb(0, 0, 0, 0));

                BmpOptions options = new BmpOptions
                {
                    Compression = BitmapCompression.Bitfields
                };

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
 * 1. When a C# developer needs to rotate a BMP file by an arbitrary angle, such as 45°, while preserving the original dimensions and filling the newly created empty corners with a transparent background for later compositing.
 * 2. When an application must programmatically adjust the orientation of legacy BMP assets in a Windows desktop UI and ensure the rotated image remains compatible with BMP compression settings like Bitfields.
 * 3. When a game engine imports BMP textures that require precise angular alignment and the developer wants to use Aspose.Imaging to rotate them and keep the transparent padding for seamless tiling.
 * 4. When a batch‑processing tool processes scanned BMP diagrams, rotates each page to correct skew, and needs the background to be transparent so the diagrams can be overlaid on other graphics without visible borders.
 * 5. When a document‑generation service creates custom BMP icons, rotates them to match user‑specified angles, and saves the result with transparent fill to maintain visual consistency across different output formats.
 */