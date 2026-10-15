// HOW-TO: Resize PNG to 1024x768 and Convert to PDF in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Resize(1024, 768);
                image.Save(outputPath, new PdfOptions());
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
 * 1. When a web application needs to generate printable PDF reports from user‑uploaded PNG screenshots at a standard 1024×768 size.
 * 2. When an automated batch job must shrink large PNG assets and bundle them as PDFs for archival or email distribution.
 * 3. When a desktop tool converts product‑catalog images from PNG to PDF while ensuring they fit a predefined page layout.
 * 4. When a document‑generation service resizes PNG logos to a consistent resolution before embedding them in PDF invoices.
 * 5. When a migration script prepares PNG graphics for a PDF‑based e‑learning platform by resizing them to 1024×768 pixels.
 */
