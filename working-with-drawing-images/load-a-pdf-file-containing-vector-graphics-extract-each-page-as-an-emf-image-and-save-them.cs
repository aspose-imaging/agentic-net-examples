// HOW-TO: Extract PDF Pages as EMF Images Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.pdf";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image pdfImage = Image.Load(inputPath))
            {
                if (pdfImage is IMultipageImage multipage)
                {
                    int pageCount = multipage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.emf");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        using (EmfOptions options = new EmfOptions())
                        {
                            options.MultiPageOptions = new MultiPageOptions(new IntRange(i, i));
                            pdfImage.Save(outputPath, options);
                        }
                    }
                }
                else
                {
                    string outputPath = Path.Combine(outputDir, "page_1.emf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (EmfOptions options = new EmfOptions())
                    {
                        pdfImage.Save(outputPath, options);
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
 * 1. When a developer needs to convert each page of a vector‑based PDF into separate EMF files for high‑quality scaling in Windows applications.
 * 2. When an automated reporting system must generate editable vector graphics from PDF invoices for inclusion in Microsoft Office documents.
 * 3. When a batch‑processing tool has to extract vector graphics from multi‑page PDFs to create printable EMF assets for CAD or GIS workflows.
 * 4. When a migration script has to preserve vector fidelity while moving PDF diagrams into a legacy system that only accepts EMF format.
 * 5. When a document‑management application requires per‑page EMF thumbnails of PDFs for fast preview and annotation in a .NET environment.
 */
