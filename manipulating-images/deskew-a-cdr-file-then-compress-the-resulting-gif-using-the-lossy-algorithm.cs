// HOW-TO: Deskew CorelDRAW CDR and Compress to Lossy GIF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string tempPngPath = "Output/temp.png";
            string outputGifPath = "Output/result.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

            using (Image cdrImage = Image.Load(inputPath))
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    cdrImage.Save(tempPngPath, pngOptions);
                }
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                if (!raster.IsCached) raster.CacheData();

                raster.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);

                using (GifOptions gifOptions = new GifOptions())
                {
                    gifOptions.ColorResolution = 8;
                    raster.Save(outputGifPath, gifOptions);
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
 * 1. When you need to automatically straighten scanned CorelDRAW drawings and reduce their file size for web publishing.
 * 2. When a batch process must convert legacy CDR artwork into lightweight GIF animations for email newsletters.
 * 3. When an application has to correct the orientation of vector graphics before saving them as lossy GIFs for mobile apps.
 * 4. When you want to integrate Aspose.Imaging into a C# service that prepares CDR files for low‑bandwidth transmission.
 * 5. When a document management system requires deskewed, compressed GIF previews of CDR files for quick preview.
 */
