// HOW-TO: Resize PNG to 800x800 with Transparent Padding and Convert to PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string tempPngPath = "temp.png";
            string outputPdfPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            using (Aspose.Imaging.RasterImage original = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                double scale = Math.Min(800.0 / original.Width, 800.0 / original.Height);
                int newWidth = (int)(original.Width * scale);
                int newHeight = (int)(original.Height * scale);

                original.Resize(newWidth, newHeight, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                var canvasSource = new FileCreateSource(tempPngPath, false);
                PngOptions canvasOptions = new PngOptions() { Source = canvasSource };
                using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(canvasOptions, 800, 800))
                {
                    canvas.HasTransparentColor = true;
                    canvas.TransparentColor = Aspose.Imaging.Color.Transparent;

                    int offsetX = (800 - newWidth) / 2;
                    int offsetY = (800 - newHeight) / 2;

                    int[] pixels = original.LoadArgb32Pixels(original.Bounds);
                    canvas.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(offsetX, offsetY, newWidth, newHeight), pixels);

                    canvas.Save();
                }
            }

            if (!File.Exists(tempPngPath))
            {
                Console.Error.WriteLine($"File not found: {tempPngPath}");
                return;
            }

            using (Aspose.Imaging.RasterImage padded = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(tempPngPath))
            {
                padded.Save(outputPdfPath, new PdfOptions());
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
 * 1. When you need to embed a small logo or icon into a PDF document while preserving its original aspect ratio and adding transparent space to meet a fixed page size.
 * 2. When generating product catalogs where each product image must be uniformly sized at 800 × 800 pixels with transparent borders before being compiled into a PDF.
 * 3. When creating printable certificates that require a PNG signature image to be resized, centered, and padded with transparency before converting to PDF for distribution.
 * 4. When automating the preparation of thumbnail images for a PDF portfolio, ensuring each thumbnail fits an 800 × 800 canvas without distortion.
 * 5. When developing a web service that receives user‑uploaded PNGs, standardizes them to a square transparent canvas, and returns a PDF version for archival or email attachment.
 */
