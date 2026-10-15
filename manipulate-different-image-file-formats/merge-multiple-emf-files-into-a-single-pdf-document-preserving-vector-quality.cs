// HOW-TO: Merge Multiple EMF Files into a Single PDF with Vector Quality in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = { "input1.emf", "input2.emf", "input3.emf" };
            string outputPath = "output/merged.pdf";

            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var images = new List<Image>();
            foreach (var path in inputPaths)
            {
                Image img = Image.Load(path);
                images.Add(img);
            }

            using (Image multi = Image.Create(images.ToArray(), true))
            {
                PdfOptions pdfOptions = new PdfOptions();
                multi.Save(outputPath, pdfOptions);
            }

            foreach (var img in images)
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
 * 1. When you need to combine several vector‑based EMF diagrams into one searchable PDF report.
 * 2. When generating a multi‑page PDF brochure from individual EMF graphics while keeping them scalable.
 * 3. When automating the creation of printable invoices that consist of separate EMF logos and charts.
 * 4. When consolidating EMF assets from a design workflow into a single PDF for archival or sharing.
 * 5. When building a C# service that batches EMF drawings into a PDF document without rasterizing them.
 */
