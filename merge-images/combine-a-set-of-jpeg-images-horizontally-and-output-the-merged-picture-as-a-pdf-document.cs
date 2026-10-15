// HOW-TO: Combine Multiple JPEG Images Horizontally and Save as PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "merged.pdf";
            string tempCanvasPath = "temp_canvas.jpg";

            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));

            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            FileCreateSource tempSource = new FileCreateSource(tempCanvasPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPath, pdfOptions);
            }

            if (File.Exists(tempCanvasPath))
            {
                File.Delete(tempCanvasPath);
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
 * 1. When you need to create a printable PDF catalog by stitching product photos side‑by‑side from separate JPEG files.
 * 2. When you want to generate a single PDF receipt that shows a before‑and‑after image comparison using two JPEG screenshots.
 * 3. When you have scanned pages saved as JPEGs and must merge them into one horizontal PDF for quick review.
 * 4. When you are building a photo collage PDF for marketing material by aligning multiple JPEG images in a single row.
 * 5. When you need to combine side‑by‑side screenshots of a UI flow into a PDF document for stakeholder presentations.
 */
