// HOW-TO: Convert Single Page CDR to Transparent PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cdr");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    options.ColorType = PngColorType.TruecolorWithAlpha;
                    cdr.Save(outputPath, options);
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
 * 1. When you need to display a CorelDRAW logo on a website without a background, you can convert the CDR to a PNG with an alpha channel.
 * 2. When automating a batch process that extracts a single‑page illustration from a CDR file and saves it as a transparent PNG for use in UI assets.
 * 3. When integrating legacy CDR artwork into a .NET desktop application that only supports PNG images with transparency.
 * 4. When preparing print‑ready graphics for e‑commerce product listings that require PNG files with preserved transparent backgrounds.
 * 5. When creating thumbnails of CDR designs for a content‑management system that stores images as PNG with alpha transparency.
 */
