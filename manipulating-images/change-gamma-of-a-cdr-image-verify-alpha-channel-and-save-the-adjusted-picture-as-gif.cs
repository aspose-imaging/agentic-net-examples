// HOW-TO: Change Gamma Of CDR Image, Check Alpha, Save As GIF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var cdr = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Image.Load(inputPath))
            {
                using (var ms = new MemoryStream())
                {
                    // Rasterize CDR to GIF format in memory
                    cdr.Save(ms, new GifOptions());
                    ms.Position = 0;

                    using (GifImage gif = (GifImage)Image.Load(ms))
                    {
                        // Verify alpha channel presence
                        bool hasAlpha = gif.HasAlpha;
                        Console.WriteLine($"Has Alpha: {hasAlpha}");

                        // Adjust gamma
                        gif.AdjustGamma(2.2f);

                        // Save adjusted image as GIF
                        gif.Save(outputPath, new GifOptions());
                    }
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
 * 1. When you need to convert a CorelDRAW (CDR) vector file to a GIF while adjusting its brightness through gamma correction.
 * 2. When you must verify whether the GIF produced from a CDR file contains an alpha channel before using it in further image processing.
 * 3. When an application requires on‑the‑fly rasterization of CDR files to GIF format for web‑compatible output with consistent color rendering.
 * 4. When you are building a .NET service that programmatically modifies image gamma and validates alpha channels using Aspose.Imaging.
 * 5. When you want to automate batch processing of CDR assets, applying gamma correction and saving the results as optimized GIF files.
 */
