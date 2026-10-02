// HOW-TO: Convert WMF to 24‑Bit BMP in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.wmf";
                string outputPath = "output.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24
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
 * 1. When you need to display legacy WMF vector graphics in a Windows application that only supports bitmap images, you can convert them to 24‑bit BMP to preserve full color.
 * 2. When generating printable reports that require high‑resolution raster images, converting WMF diagrams to 24‑bit BMP ensures accurate color reproduction.
 * 3. When integrating with third‑party APIs that accept only BMP files, you can use this code to transform WMF assets into 24‑bit BMP before upload.
 * 4. When archiving design assets in a uniform format, converting WMF files to 24‑bit BMP simplifies storage and viewing across different platforms.
 * 5. When performing batch image processing in a C# service, this snippet lets you reliably convert multiple WMF files to full‑color BMP files for downstream processing.
 */
