// HOW-TO: Add Author Metadata to PDF Created from Horizontal JPEG Merge in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDirectory);

            string[] imageFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            if (imageFiles.Length == 0)
            {
                Console.Error.WriteLine("No JPEG files found in input directory.");
                return;
            }

            var dimensions = new List<(int Width, int Height)>();
            foreach (string file in imageFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    dimensions.Add((img.Width, img.Height));
                }
            }

            int totalWidth = dimensions.Sum(d => d.Width);
            int maxHeight = dimensions.Max(d => d.Height);

            string tempCanvasPath = Path.Combine(outputDirectory, "temp_canvas.jpg");
            Source tempSource = new FileCreateSource(tempCanvasPath, true);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                for (int i = 0; i < imageFiles.Length; i++)
                {
                    string file = imageFiles[i];
                    using (RasterImage img = (RasterImage)Image.Load(file))
                    {
                        var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                string outputPdfPath = Path.Combine(outputDirectory, "merged.pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                pdfOptions.PdfDocumentInfo.Author = "Custom Author";

                canvas.Save(outputPdfPath, pdfOptions);
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
 * 1. When you need to combine several scanned JPEG pages into a single PDF and embed the author's name for document tracking.
 * 2. When generating a PDF report from a series of product photos and want the author field to show the photographer's name.
 * 3. When automating the creation of e‑books from image chapters and must include author metadata for compliance with publishing standards.
 * 4. When building a document management system that merges uploaded JPEG invoices into a PDF and records the user who uploaded them.
 * 5. When creating archival PDFs from horizontal image strips and need to embed author information for future search and retrieval.
 */
