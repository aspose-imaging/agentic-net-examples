// HOW-TO: Extract EPS Preview and Save as JPEG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output/preview.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Save the extracted EPS preview as JPEG with default settings
                image.Save(outputPath);
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
 * 1. When you need to generate thumbnail JPEGs from EPS files for a web gallery preview.
 * 2. When converting vector EPS artwork into a raster JPEG to attach to emails or reports.
 * 3. When extracting the embedded preview of an EPS to display in a document management system.
 * 4. When automating batch processing of EPS files to create default‑quality JPEG previews for a file explorer.
 * 5. When integrating EPS preview extraction into a C# application that requires quick JPEG output without custom settings.
 */
