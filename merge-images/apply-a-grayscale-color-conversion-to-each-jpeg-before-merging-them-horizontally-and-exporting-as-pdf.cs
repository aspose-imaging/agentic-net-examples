// HOW-TO: Convert Multiple JPEGs to Grayscale and Merge Horizontally into PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging;
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
            string inputDirectory = "Input";
            string outputPath = "Output/merged.pdf";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");

            List<RasterImage> images = new List<RasterImage>();
            List<Size> sizes = new List<Size>();

            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                RasterImage img = (RasterImage)Image.Load(file);
                img.Grayscale();
                images.Add(img);
                sizes.Add(new Size(img.Width, img.Height));
            }

            if (images.Count == 0)
            {
                Console.Error.WriteLine("No images to process.");
                return;
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (RasterImage img in images)
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }

                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPath, pdfOptions);
            }

            foreach (RasterImage img in images)
            {
                img.Dispose();
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
 * 1. When you need to generate a printable PDF catalog from a collection of color JPEG photos by converting each image to grayscale and stitching them side‑by‑side to reduce printing costs.
 * 2. When an e‑commerce platform must create a single PDF invoice that contains multiple product JPEGs merged horizontally in black‑and‑white to keep the file size low.
 * 3. When a document management system has to archive scanned JPEG receipts as one grayscale PDF page for compliance and easier text extraction.
 * 4. When a reporting tool requires combining several camera snapshots into a horizontal PDF page with uniform grayscale tone for consistent visual analysis.
 * 5. When a batch‑processing script automatically converts color JPEGs to grayscale, merges them horizontally, and outputs a PDF for archival or distribution without manual editing.
 */
