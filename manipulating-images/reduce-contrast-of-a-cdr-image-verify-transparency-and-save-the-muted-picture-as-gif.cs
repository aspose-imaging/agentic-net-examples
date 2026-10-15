// HOW-TO: Reduce Contrast of CDR Image, Check Transparency, Save as GIF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
                        raster.AdjustContrast(-0.5f);

                        bool hasTransparency = false;
                        for (int y = 0; y < raster.Height && !hasTransparency; y++)
                        {
                            for (int x = 0; x < raster.Width; x++)
                            {
                                Aspose.Imaging.Color color = raster.GetPixel(x, y);
                                if (color.A < 255)
                                {
                                    hasTransparency = true;
                                    break;
                                }
                            }
                        }
                        Console.WriteLine(hasTransparency ? "Image has transparency." : "Image is fully opaque.");

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
 * 1. When you need to lower the contrast of a CorelDRAW (CDR) file before converting it to a web‑friendly GIF while preserving any transparent areas.
 * 2. When an application must programmatically verify that a converted image still contains alpha transparency after processing.
 * 3. When you want to batch‑process CDR drawings, adjust their visual tone, and output lightweight GIFs for email newsletters.
 * 4. When integrating Aspose.Imaging into a C# service that receives CDR uploads, normalizes their contrast, and stores the result as a GIF for preview thumbnails.
 * 5. When converting vector CDR artwork to a raster PNG in memory, applying contrast reduction, and then saving the final muted picture as a GIF without writing intermediate files to disk.
 */
