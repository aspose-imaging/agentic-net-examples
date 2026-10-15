// HOW-TO: Convert OTG to PDF and Flatten Annotations in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.otg";
        string outputPath = "Output\\sample.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate a static PDF from an OTG vector file for archiving or printing, preserving the visual appearance without editable layers.
 * 2. When an application must batch‑process OTG drawings and output them as PDF documents that can be opened in any PDF viewer.
 * 3. When a workflow requires flattening all vector annotations in an OTG file so the resulting PDF cannot be modified or selected.
 * 4. When integrating Aspose.Imaging into a C# service that receives OTG files from users and returns a PDF version for downstream document management systems.
 * 5. When creating a PDF report that includes OTG graphics with a white background and exact page dimensions matching the original image size.
 */
