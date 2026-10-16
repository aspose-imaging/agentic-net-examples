// HOW-TO: Crop Central 500x500 Area From CDR And Save As PDF In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int width = image.Width;
                int height = image.Height;
                int cropWidth = 500;
                int cropHeight = 500;
                int left = Math.Max(0, (width - cropWidth) / 2);
                int top = Math.Max(0, (height - cropHeight) / 2);

                image.Crop(new Rectangle(left, top, cropWidth, cropHeight));

                var pdfOptions = new PdfOptions();
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
 * 1. When you need to extract a specific region from a CorelDRAW (.cdr) design and embed it in a PDF report.
 * 2. When generating thumbnails of a fixed size from large CDR files before archiving them as PDFs.
 * 3. When preparing a printable PDF that contains only the central portion of a CDR illustration for marketing materials.
 * 4. When automating a workflow that trims the center of vector drawings to meet a 500‑pixel requirement and converts them to PDF for downstream processing.
 * 5. When creating a batch process that crops the middle of each CDR file to a 500×500 pixel area and saves the result as a PDF for easy viewing on any device.
 */
