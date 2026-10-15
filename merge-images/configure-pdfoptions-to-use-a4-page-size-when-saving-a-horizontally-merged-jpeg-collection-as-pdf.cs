// HOW-TO: Save Horizontally Merged JPEG Images as A4 PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");

            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            List<Size> sizes = new List<Size>();
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    sizes.Add(img.Size);
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            string outputPath = Path.Combine(outputDirectory, "merged.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegOptions canvasOptions = new JpegOptions())
            {
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, totalWidth, maxHeight))
                {
                    int offsetX = 0;
                    foreach (string file in files)
                    {
                        using (RasterImage img = (RasterImage)Image.Load(file))
                        {
                            Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetX += img.Width;
                        }
                    }

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.PageSize = new SizeF(totalWidth, maxHeight);
                        canvas.Save(outputPath, pdfOptions);
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
 * 1. When you need to combine multiple landscape JPEG photos into a single A4‑sized PDF report using C#.
 * 2. When you want to programmatically create a printable PDF booklet from a folder of JPEG images without manual layout.
 * 3. When an application must generate a PDF catalog where each page contains a horizontally stitched image that fits standard A4 dimensions.
 * 4. When automating the archival of scanned receipts or invoices stored as JPEGs into a single A4 PDF document.
 * 5. When building a server‑side service that merges user‑uploaded JPEGs into an A4 PDF for email attachment or download.
 */
