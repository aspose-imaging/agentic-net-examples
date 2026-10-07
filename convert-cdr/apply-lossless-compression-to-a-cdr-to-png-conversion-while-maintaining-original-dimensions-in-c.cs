// HOW-TO: Convert CDR to PNG with Maximum Lossless Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cdr;

public class Program
{
    public static void Main(string[] args)
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

            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    options.PngCompressionLevel = PngCompressionLevel.ZipLevel9;
                    image.Save(outputPath, options);
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
 * 1. When you need to export a CorelDRAW (.cdr) illustration to a PNG for web use while keeping the original size and without any quality loss.
 * 2. When an automated build process must generate high‑quality PNG assets from CDR source files for a mobile app, using Aspose.Imaging in C#.
 * 3. When a document‑management system stores vector designs in CDR and requires losslessly compressed PNG thumbnails that match the original dimensions.
 * 4. When a batch conversion tool must preserve the exact pixel dimensions of CDR artwork while applying the strongest PNG compression to reduce storage costs.
 * 5. When integrating a C# service that creates printable PNGs from CDR logos, ensuring the output is fully lossless and retains the original layout.
 */
