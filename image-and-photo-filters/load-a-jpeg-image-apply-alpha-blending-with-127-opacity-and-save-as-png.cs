// HOW-TO: Apply Semi Transparent Blend To JPEG And Export PNG Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage background = (RasterImage)Image.Load(inputPath))
            using (RasterImage overlay = (RasterImage)Image.Load(inputPath))
            {
                background.Blend(new Point(0, 0), overlay, 127);

                PngOptions pngOptions = new PngOptions()
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                background.Save(outputPath, pngOptions);
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
 * 1. When you need to create a watermark effect by overlaying a JPEG onto itself with 50% opacity and saving the result as a PNG with transparency.
 * 2. When you want to convert a JPEG image to a PNG while preserving a semi‑transparent alpha channel for web graphics.
 * 3. When you are generating UI assets that require a PNG with partial opacity derived from an existing JPEG source.
 * 4. When you need to programmatically blend two identical images to test alpha‑blending logic before applying it to different layers.
 * 5. When you are building an image‑processing pipeline that must output PNG files with a specific opacity level for printing or publishing.
 */
