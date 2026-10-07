// HOW-TO: Convert BMP Image to PNG While Preserving Color Depth in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
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
 * 1. When you need to convert legacy BMP graphics to PNG for web delivery without losing the original palette or alpha channel.
 * 2. When an application must batch‑process user‑uploaded BMP files and store them as lossless PNGs while keeping transparency intact.
 * 3. When migrating a desktop software’s assets from BMP to PNG to reduce file size but still require the exact color depth for accurate rendering.
 * 4. When integrating Aspose.Imaging in a C# service that receives BMP images and must return PNGs that preserve the original image’s transparency for further compositing.
 * 5. When automating a build pipeline that generates documentation screenshots in BMP and needs them saved as PNGs with the same visual fidelity.
 */
