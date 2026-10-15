// HOW-TO: Convert ODG to PNG with Gamma Correction in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image odgImage = Image.Load(inputPath))
            {
                using (var ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    odgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        if (!raster.IsCached) raster.CacheData();
                        raster.AdjustGamma(2.2f);
                        raster.Save(outputPath);
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
 * 1. When you need to display OpenDocument graphics on the web, you can convert the ODG file to a PNG image and adjust its gamma so the colors appear with correct brightness across browsers.
 * 2. When generating thumbnails for a document management system, you can use this code to transform ODG drawings into PNG thumbnails while applying gamma correction to ensure consistent visual quality.
 * 3. When preparing print‑ready assets from ODG source files, applying a 2.2 gamma correction before saving as PNG helps match the perceived brightness of the final printed output.
 * 4. When integrating Aspose.Imaging into a C# application that processes user‑uploaded ODG files, this snippet converts them to PNG and normalizes brightness, making the images suitable for further analysis or storage.
 * 5. When building a batch conversion tool for legacy OpenDocument graphics, you can automate the conversion to PNG and apply gamma correction to maintain accurate color representation on modern displays.
 */
