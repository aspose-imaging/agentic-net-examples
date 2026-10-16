// HOW-TO: Create Animated APNG From Multi‑Page TIFF In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.tif";
            string outputPath = "Output/animated.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiffImage = Image.Load(inputPath))
            {
                if (!(tiffImage is IMultipageImage multipage))
                {
                    Console.Error.WriteLine("Input image is not a multipage image.");
                    return;
                }

                using (RasterImage firstPage = (RasterImage)multipage.Pages[0])
                {
                    int width = firstPage.Width;
                    int height = firstPage.Height;

                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                    {
                        apng.RemoveAllFrames();

                        for (int i = 0; i < multipage.PageCount; i++)
                        {
                            using (RasterImage page = (RasterImage)multipage.Pages[i])
                            {
                                if (!page.IsCached) page.CacheData();

                                apng.AddFrame(page);
                            }
                        }

                        apng.Save();
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
 * 1. When you need to convert a scanned multi‑page TIFF document into a compact animated PNG for fast web preview.
 * 2. When you want to generate an animated thumbnail from a series of TIFF frames for display in a mobile app.
 * 3. When you have multi‑page medical images exported as TIFF and must show them as an APNG slideshow in a .NET application.
 * 4. When you need to turn a TIFF sprite sheet into a frame‑by‑frame APNG animation for a game UI using C#.
 * 5. When you must batch‑process archival TIFF files into APNGs with individual frame timing for an e‑learning platform.
 */
