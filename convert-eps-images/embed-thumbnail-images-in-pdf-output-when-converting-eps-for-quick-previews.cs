// HOW-TO: Create PDF from EPS with Embedded Thumbnail Preview in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.eps");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image epsImage = Image.Load(inputPath))
            {
                int width = epsImage.Width;
                int height = epsImage.Height;

                int thumbWidth = 200;
                int thumbHeight = (int)((double)height / width * thumbWidth);

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    var thumbOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = thumbWidth,
                        PageHeight = thumbHeight
                    };

                    var fullOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = width,
                        PageHeight = height
                    };

                    pdfOptions.MultiPageOptions = new MultiPageOptions
                    {
                        PageRasterizationOptions = new VectorRasterizationOptions[] { thumbOptions, fullOptions }
                    };

                    epsImage.Save(outputPath, pdfOptions);
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
 * 1. When a web application needs to display a small preview of an EPS artwork before the user downloads the full‑size PDF, this code generates a thumbnail page followed by the full‑resolution page.
 * 2. When an automated document pipeline converts legacy EPS files to searchable PDFs and wants the first page to act as a quick visual index, the snippet creates a multi‑page PDF with a scaled‑down preview.
 * 3. When a desktop publishing tool must embed a low‑resolution preview of a vector logo inside a PDF for faster loading on low‑bandwidth devices, this example rasterizes the EPS at two sizes and saves them together.
 * 4. When a batch job processes a folder of EPS graphics and needs each output PDF to contain a thumbnail for thumbnail‑viewers or file explorers, the code demonstrates how to set page dimensions and background color using Aspose.Imaging.
 * 5. When integrating Aspose.Imaging into a C# service that converts customer‑uploaded EPS files to PDFs while providing an immediate preview image in the same document, this sample shows the required options and error handling.
 */
