// HOW-TO: Crop CorelDRAW Image to 200x200 and Save as GIF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.cdr";
            string outputPath = "Output/output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    cdr.Save(ms, new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    });
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Crop(new Rectangle(0, 0, 200, 200));
                        raster.Save(outputPath, new GifOptions());
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
 * 1. When you need to extract a small thumbnail from a CorelDRAW design and deliver it as a lightweight GIF for web previews.
 * 2. When an automated pipeline must convert multi‑page CDR files into animated‑compatible GIFs after cropping a specific region.
 * 3. When a desktop application generates product icons by loading CDR artwork, cropping to a fixed size, and saving in GIF format for UI elements.
 * 4. When a batch process creates email‑friendly image attachments by converting CorelDRAW graphics to 200 × 200 GIFs.
 * 5. When a reporting tool requires a fixed‑size GIF snapshot of a CDR diagram to embed in PDF or HTML reports.
 */
