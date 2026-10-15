// HOW-TO: Split A BigTIFF Image Into Four PNG Quadrants Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (BigTiffImage bigTiff = (BigTiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage source = bigTiff;

                int width = source.Width;
                int height = source.Height;
                int halfW = width / 2;
                int halfH = height / 2;

                for (int i = 0; i < 4; i++)
                {
                    int x = (i % 2) * halfW;
                    int y = (i / 2) * halfH;

                    int[] pixels = source.LoadArgb32Pixels(new Aspose.Imaging.Rectangle(x, y, halfW, halfH));

                    string outputPath = Path.Combine(outputDir, $"quadrant{i + 1}.png");

                    var pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    using (Aspose.Imaging.RasterImage quad = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pngOptions, halfW, halfH))
                    {
                        quad.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, halfW, halfH), pixels);
                        quad.Save();
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
 * 1. When you need to break a massive satellite BigTIFF file into four smaller PNG tiles for faster web rendering.
 * 2. When a medical imaging workflow stores scans as BigTIFF and you must extract each quadrant as separate PNGs for detailed analysis.
 * 3. When generating preview thumbnails of different sections of a high‑resolution map saved in BigTIFF format.
 * 4. When preparing image data for a machine‑learning model that requires smaller PNG inputs derived from a large source file.
 * 5. When creating printable sections of a large engineering drawing stored as BigTIFF, saving each quadrant as an individual PNG for separate printing.
 */
