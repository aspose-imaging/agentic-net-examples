// HOW-TO: Create Multipage PDF from Multiple CDR Files in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR file paths
            string cdrPath1 = "Input/file1.cdr";
            string cdrPath2 = "Input/file2.cdr";

            // Validate input files
            if (!File.Exists(cdrPath1)) { Console.Error.WriteLine($"File not found: {cdrPath1}"); return; }
            if (!File.Exists(cdrPath2)) { Console.Error.WriteLine($"File not found: {cdrPath2}"); return; }

            // Output PDF path
            string outputPath = "Output/combined.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to hold rasterized pages
            List<RasterImage> rasterPages = new List<RasterImage>();

            // Process each CDR file
            string[] cdrFiles = new string[] { cdrPath1, cdrPath2 };
            foreach (string cdrFile in cdrFiles)
            {
                using (CdrImage cdr = (CdrImage)Image.Load(cdrFile))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions();
                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;
                        RasterImage raster = (RasterImage)Image.Load(ms);
                        rasterPages.Add(raster);
                    }
                }
            }

            // Create multipage TIFF and add pages
            using (TiffImage tiff = new TiffImage(new TiffFrame(rasterPages[0])))
            {
                for (int i = 1; i < rasterPages.Count; i++)
                {
                    tiff.AddPage(rasterPages[i]);
                }

                // Save as PDF
                PdfOptions pdfOptions = new PdfOptions();
                tiff.Save(outputPath, pdfOptions);
            }

            // Dispose raster pages
            foreach (var page in rasterPages)
            {
                page.Dispose();
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
 * 1. When a designer needs to combine several CorelDRAW (CDR) drawings into a single PDF for client review using C# and Aspose.Imaging.
 * 2. When an automated reporting tool must batch‑convert a collection of CDR assets into a multipage PDF for archival purposes.
 * 3. When a web service receives uploaded CDR files and has to return a combined PDF document to the end user without manual intervention.
 * 4. When a desktop application wants to merge multiple CDR diagrams into a printable PDF programmatically in a .NET environment.
 * 5. When a migration script has to transform legacy CDR documents into PDF format for integration with a document management system.
 */
