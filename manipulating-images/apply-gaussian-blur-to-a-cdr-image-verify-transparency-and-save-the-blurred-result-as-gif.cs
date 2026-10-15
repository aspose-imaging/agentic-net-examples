// HOW-TO: Apply Gaussian Blur to CDR Image and Save as GIF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputCdrPath = "input.cdr";
        string outputGifPath = "output.gif";

        if (!File.Exists(inputCdrPath))
        {
            Console.Error.WriteLine($"File not found: {inputCdrPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath) ?? ".");

        try
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputCdrPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
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
                        var blurOptions = new GaussianBlurFilterOptions(5, 1.0f);
                        raster.Filter(raster.Bounds, blurOptions);

                        bool hasTransparency = false;
                        int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                        foreach (int pixel in pixels)
                        {
                            int alpha = (pixel >> 24) & 0xFF;
                            if (alpha < 255)
                            {
                                hasTransparency = true;
                                break;
                            }
                        }
                        Console.WriteLine(hasTransparency ? "Image has transparency." : "Image is fully opaque.");

                        var gifOptions = new GifOptions();
                        raster.Save(outputGifPath, gifOptions);
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
 * 1. When you need to add a soft blur effect to a CorelDRAW illustration before embedding it in a web page as a GIF.
 * 2. When you must convert a vector CDR file to a raster format, apply image processing, and preserve any transparent areas for UI assets.
 * 3. When an automated pipeline has to generate blurred thumbnails from CDR designs and store them as lightweight GIF files.
 * 4. When you want to verify that a converted CDR image retains alpha channel information after applying filters.
 * 5. When you are building a C# application that programmatically manipulates CorelDRAW graphics, applies Gaussian blur, and outputs them for email newsletters.
 */
