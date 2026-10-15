// HOW-TO: Convert BMP Image to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
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
        try
        {
            string inputPath = Path.Combine("Input", "image.bmp");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a PDF report that includes scanned BMP graphics, you can load the BMP and save it directly as a PDF with Aspose.Imaging in C#.
 * 2. When archiving legacy BMP assets for long‑term storage, converting them to PDF reduces file size and ensures compatibility across platforms.
 * 3. When creating printable documents that require high‑resolution BMP images, embedding the BMP into a PDF guarantees consistent layout and printing results.
 * 4. When documenting software screenshots saved as BMP files, converting them to PDF simplifies sharing and version control in C# applications.
 * 5. When automating an e‑signature workflow that only accepts PDF inputs, converting incoming BMP images to PDF streamlines the processing pipeline.
 */
