// HOW-TO: Deskew a TIFF, Detect Transparency, and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\deskewed.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.NormalizeAngle(false, Color.LightGray);

                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                bool hasTransparency = false;
                foreach (int pixel in pixels)
                {
                    if ((pixel >> 24) != 255)
                    {
                        hasTransparency = true;
                        break;
                    }
                }
                Console.WriteLine($"Transparency detected: {hasTransparency}");

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to correct the rotation of scanned TIFF documents before converting them to web‑friendly PNGs.
 * 2. When you must verify whether a scanned image contains any transparent pixels prior to further processing.
 * 3. When an automated pipeline has to normalize the angle of multi‑page TIFF files and preserve any existing alpha channel.
 * 4. When you are building a C# service that receives TIFF uploads, deskews them, and stores the result as PNG for display in browsers.
 * 5. When you want to ensure a TIFF image is properly cached, deskewed, and saved with PNG compression while checking for transparency in a .NET application.
 */
