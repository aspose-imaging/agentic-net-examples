// HOW-TO: Set PNG Compression Level When Converting BMP to PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input/source.bmp";
            string outputPath = "output/converted.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 6 // balance file size and quality
                };
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to reduce the file size of a BMP image while keeping visual quality acceptable for web delivery, you can convert it to PNG with a balanced compression level in C#.
 * 2. When generating thumbnails for a photo gallery, you may want to save the images as PNG with moderate compression to ensure fast loading without noticeable artifacts.
 * 3. When archiving scanned documents as lossless PNG files, setting a specific compression level helps keep storage costs low while preserving detail.
 * 4. When processing batch image conversions in a server‑side .NET application, configuring the PNG compression level allows you to control the trade‑off between bandwidth and image fidelity.
 * 5. When integrating Aspose.Imaging into an automated build pipeline that outputs PNG assets, adjusting the compression level ensures consistent output size across different environments.
 */
