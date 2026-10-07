// HOW-TO: Convert ODG to 8‑Bit BMP with Reduced File Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ConvertOdgToBmp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
                string outputPath = "output.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var image = Image.Load(inputPath))
                {
                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 8
                    };
                    image.Save(outputPath, bmpOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed an OpenDocument graphics (ODG) illustration into a legacy Windows application that only supports 8‑bit BMP images.
 * 2. When you want to shrink the storage footprint of vector drawings by converting them to a palette‑based BMP for faster loading over a network.
 * 3. When an automated batch process must convert user‑uploaded ODG files to BMP thumbnails while limiting colors to 256 to meet size constraints.
 * 4. When a reporting tool requires BMP images with a fixed 8‑bit depth, and you must transform source ODG diagrams programmatically in C#.
 * 5. When migrating design assets from LibreOffice Draw to a .NET‑based system that stores images as compressed BMP files with a reduced palette.
 */
