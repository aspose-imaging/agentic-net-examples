// HOW-TO: Merge Multiple WMF Files Into a Single PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] wmfFiles = {
                "input1.wmf",
                "input2.wmf",
                "input3.wmf"
            };

            string outputPdf = "output/merged.pdf";

            string outputDir = Path.GetDirectoryName(outputPdf);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            foreach (string path in wmfFiles)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            var images = new List<Aspose.Imaging.Image>();
            foreach (string path in wmfFiles)
            {
                Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(path);
                images.Add(img);
            }

            using (Aspose.Imaging.Image multi = Aspose.Imaging.Image.Create(images.ToArray(), true))
            {
                PdfOptions pdfOptions = new PdfOptions();
                multi.Save(outputPdf, pdfOptions);
            }

            foreach (Aspose.Imaging.Image img in images)
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
 * 1. When a developer needs to combine several WMF vector drawings into one PDF report for easy sharing.
 * 2. When an application must programmatically generate a PDF portfolio from a list of WMF icons or diagrams.
 * 3. When automating the conversion of legacy WMF assets to PDF for archival or compliance purposes.
 * 4. When building a batch processing tool that validates the existence of each WMF file before creating a consolidated PDF.
 * 5. When integrating Aspose.Imaging into a C# workflow to render WMF images and save them as a multi‑page PDF document.
 */
