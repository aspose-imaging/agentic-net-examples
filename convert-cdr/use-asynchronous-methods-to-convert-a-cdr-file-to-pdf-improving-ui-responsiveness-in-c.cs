// HOW-TO: Asynchronously Convert CorelDRAW CDR to PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            string inputPath = "input/input.cdr";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            await Task.Run(() =>
            {
                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to let users open CorelDRAW files and export them as PDFs without freezing the UI.
 * 2. When a web service processes uploaded CDR designs and returns PDF previews while handling multiple requests concurrently.
 * 3. When an automated batch job converts a folder of CDR drawings to PDFs on a background thread to keep the main process responsive.
 * 4. When integrating Aspose.Imaging into a WPF app to provide real‑time PDF conversion of vector graphics while the user continues editing.
 * 5. When building a Windows Forms tool that validates the existence of a CDR file, creates the output directory, and saves the PDF asynchronously to improve performance.
 */
