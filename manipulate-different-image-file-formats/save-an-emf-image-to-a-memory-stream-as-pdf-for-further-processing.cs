// HOW-TO: Convert EMF To PDF In Memory Stream Using C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output\\output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage image = (EmfImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    image.Save(ms, pdfOptions);

                    Console.WriteLine($"PDF saved to memory stream, size: {ms.Length} bytes");

                    // Optional: write the PDF to a file for verification
                    File.WriteAllBytes(outputPath, ms.ToArray());
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
 * 1. When you need to embed a vector EMF graphic into a PDF report without writing intermediate files.
 * 2. When a web service must receive an EMF upload and return a PDF stream for downstream APIs.
 * 3. When generating printable PDFs on the fly from EMF logos in a desktop application.
 * 4. When performing batch conversion of EMF files to PDF in memory to reduce I/O overhead.
 * 5. When integrating Aspose.Imaging into a workflow that sends PDF bytes to cloud storage or email attachments.
 */
