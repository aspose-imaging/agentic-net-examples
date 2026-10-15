// HOW-TO: Create Animated WebP From Multiple BMP Images In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "frame1.bmp";
            string inputPath2 = "frame2.bmp";
            string inputPath3 = "frame3.bmp";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            string outputPath = "output/animation.webp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image firstImg = Image.Load(inputPath1))
            {
                RasterImage firstRaster = firstImg as RasterImage;
                using (WebPImage webp = new WebPImage(firstRaster))
                {
                    using (Image img2 = Image.Load(inputPath2))
                    {
                        RasterImage raster2 = img2 as RasterImage;
                        webp.AddPage(raster2);
                    }

                    using (Image img3 = Image.Load(inputPath3))
                    {
                        RasterImage raster3 = img3 as RasterImage;
                        webp.AddPage(raster3);
                    }

                    webp.Save(outputPath);
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
 * 1. When you need to convert a series of legacy BMP frames into a single animated WebP file for faster loading on web pages.
 * 2. When you want to generate animated stickers for messaging apps by combining BMP assets into a WebP animation using C#.
 * 3. When you have game sprite sheets saved as separate BMP files and require a compact animated WebP for cross‑platform deployment.
 * 4. When you must compress a step‑by‑step tutorial captured as BMP screenshots into an animated WebP to embed in documentation.
 * 5. When you are building a product showcase that animates multiple BMP renders into a WebP animation for smooth playback on mobile devices.
 */
