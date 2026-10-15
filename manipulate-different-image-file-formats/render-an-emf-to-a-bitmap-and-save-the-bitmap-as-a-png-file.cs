// HOW-TO: Convert EMF Vector Image To PNG Bitmap In C# With Aspose (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "data/Picture1.emf";
            string outputPath = "output/Picture1.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterizationOptions = new EmfRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
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
 * 1. When you need to display a Windows Metafile (EMF) on a web page that only supports raster formats like PNG.
 * 2. When you must generate high‑resolution PNG thumbnails from EMF icons for a desktop application.
 * 3. When a reporting tool exports charts as EMF and you need to embed them in PDF documents that require PNG images.
 * 4. When an automated build pipeline converts vector assets to PNG for inclusion in mobile app resources.
 * 5. When you are migrating legacy EMF graphics to a modern image library and require a lossless PNG representation for archival.
 */
