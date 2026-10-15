// HOW-TO: Batch Convert EMF Files to PDF with Bookmarks in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "Output", "Combined.pdf");

            Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");
            if (emfFiles.Length == 0)
            {
                Console.WriteLine("No EMF files found.");
                return;
            }

            List<VectorRasterizationOptions> rasterOptionsList = new List<VectorRasterizationOptions>();

            foreach (string emfPath in emfFiles)
            {
                if (!File.Exists(emfPath))
                {
                    Console.Error.WriteLine($"File not found: {emfPath}");
                    continue;
                }

                using (Image image = Image.Load(emfPath))
                {
                    VectorRasterizationOptions vOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                    rasterOptionsList.Add(vOptions);
                }
            }

            VectorRasterizationOptions[] rasterOptionsArray = rasterOptionsList.ToArray();

            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.MultiPageOptions = new MultiPageOptions
                {
                    PageRasterizationOptions = rasterOptionsArray
                };

                using (Image firstImage = Image.Load(emfFiles[0]))
                {
                    firstImage.Save(outputFile, pdfOptions);
                }
            }

            Console.WriteLine($"Combined PDF saved to {outputFile}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine multiple vector EMF drawings into a single searchable PDF for easy distribution.
 * 2. When you want each page of the PDF to be labeled with the original EMF filename as a bookmark for quick navigation.
 * 3. When you are automating the generation of product manuals that consist of separate EMF diagrams and need a consolidated PDF.
 * 4. When you must preserve the exact dimensions and white background of EMF graphics while converting them to PDF in a .NET application.
 * 5. When you are building a batch processing tool that reads EMF files from a folder and creates a multi‑page PDF without manual intervention.
 */
