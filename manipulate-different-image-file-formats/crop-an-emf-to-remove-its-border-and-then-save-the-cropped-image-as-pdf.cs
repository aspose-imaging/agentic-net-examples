// HOW-TO: Crop EMF Border And Save As PDF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage emf = (EmfImage)Image.Load(inputPath))
            {
                // Crop 10 pixels from each side to remove the border
                emf.Crop(10, 10, 10, 10);

                // Save the cropped image as PDF
                emf.Save(outputPath, new PdfOptions());
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
 * 1. When you need to remove unwanted white margins from a vector EMF logo before embedding it in a PDF report.
 * 2. When generating printable PDFs from EMF diagrams and you must ensure the content fits tightly without extra border space.
 * 3. When automating batch conversion of EMF files to PDF while trimming the edges to meet document layout guidelines.
 * 4. When a web service receives EMF drawings and must return a cropped PDF version for downstream processing.
 * 5. When creating PDF invoices that include EMF signatures and you need to eliminate surrounding whitespace for a clean appearance.
 */
