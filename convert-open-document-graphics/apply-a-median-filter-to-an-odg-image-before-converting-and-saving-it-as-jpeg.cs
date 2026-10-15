// HOW-TO: Convert ODG Vector Image to JPEG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    vectorImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(memoryStream))
                    {
                        var jpegOptions = new JpegOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };
                        raster.Save(outputPath, jpegOptions);
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
 * 1. When a document management system receives ODG drawings and must store them as compressed JPEG thumbnails for quick preview.
 * 2. When a web API needs to rasterize OpenDocument Graphics files to JPEG for browser‑compatible delivery without installing external converters.
 * 3. When a batch processing tool converts a library of ODG illustrations into JPEGs for inclusion in a printed catalog.
 * 4. When an automated workflow applies image processing (e.g., median filtering) to ODG artwork before saving it as JPEG to reduce noise in the final output.
 * 5. When a Windows desktop application loads an ODG logo, rasterizes it in memory, and saves it as a JPEG file for use in email signatures.
 */
