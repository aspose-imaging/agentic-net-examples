// HOW-TO: Compress GIF With Floyd Steinberg Dithering Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output/output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Apply Floyd‑Steinberg dithering with 8‑bit palette (256 colors)
                image.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Save as GIF; compression is handled internally
                var saveOptions = new GifOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce the file size of an animated GIF while preserving visual quality for web delivery, you can apply Floyd‑Steinberg dithering before saving with Aspose.Imaging.
 * 2. When preparing GIF assets for email newsletters that have strict attachment limits, this code lets you compress the images without losing important color details.
 * 3. When converting high‑resolution GIFs generated from video frames into lightweight versions for mobile apps, the dithering step ensures the reduced palette still looks accurate.
 * 4. When automating a batch process that optimizes user‑uploaded GIFs on a server, you can use this routine to apply 8‑bit palette dithering and save the compressed result.
 * 5. When integrating image optimization into a C# backend for a content management system, the snippet demonstrates how to shrink GIFs while maintaining visual fidelity using Aspose.Imaging.
 */
