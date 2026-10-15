// HOW-TO: Resize PNG to 1024x768 With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                image.Resize(1024, 768, ResizeType.NearestNeighbourResample);

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, options);
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
 * 1. When you need to generate thumbnail previews of user‑uploaded PNG files for a web gallery.
 * 2. When a batch process must standardize product images to 1024×768 before uploading to a CMS.
 * 3. When an automated report requires converting high‑resolution screenshots to a fixed size for PDF embedding.
 * 4. When a desktop application must resize scanned PNG documents while ensuring the image data is cached for performance.
 * 5. When a server‑side service prepares PNG assets for mobile devices by resizing them to a specific resolution.
 */
