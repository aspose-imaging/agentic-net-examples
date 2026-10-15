// HOW-TO: Extract EPS Preview Image and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

namespace EpsPreviewExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.eps";
                string outputPath = "output/preview.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
                {
                    using (Image preview = epsImage.GetPreviewImage())
                    {
                        var pngOptions = new PngOptions();
                        preview.Save(outputPath, pngOptions);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate thumbnail previews of EPS files for a web gallery.
 * 2. When you want to convert EPS artwork into a raster PNG for printing or PDF embedding.
 * 3. When an application must display EPS content on devices that only support PNG images.
 * 4. When you need to extract the embedded preview from an EPS to compare versions in a version‑control system.
 * 5. When automating batch processing of EPS files to create preview images for a digital asset management system.
 */
