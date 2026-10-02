// HOW-TO: Adjust Gamma of CDR Image, Check Alpha, Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Png;

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

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.AdjustGamma(0.8f);
                        bool hasAlpha = raster.HasAlpha;
                        Console.WriteLine($"Alpha channel present: {hasAlpha}");

                        GifOptions gifOptions = new GifOptions();
                        raster.Save(outputPath, gifOptions);
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
 * 1. When you need to darken or lighten a CorelDRAW (CDR) illustration before converting it to a web‑friendly GIF, you can adjust its gamma and preserve transparency information using Aspose.Imaging for .NET.
 * 2. When a batch process must verify whether a rasterized CDR page contains an alpha channel before exporting it to GIF for use in animated UI elements.
 * 3. When integrating a design workflow that converts high‑resolution CDR graphics to GIF while applying gamma correction to match a specific display profile.
 * 4. When troubleshooting color consistency, you can programmatically read a CDR file, modify its gamma, check for alpha, and output a GIF to compare against original assets.
 * 5. When building a .NET service that receives CDR uploads, adjusts their brightness via gamma, confirms transparency, and returns optimized GIFs for email newsletters.
 */
