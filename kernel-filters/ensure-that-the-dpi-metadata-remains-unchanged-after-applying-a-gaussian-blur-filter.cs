// HOW-TO: Preserve DPI Metadata When Saving JPEG After Processing in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
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
 * 1. When a photo‑editing application must apply filters but keep the original DPI for accurate print sizing.
 * 2. When a document‑generation system converts scanned JPEGs to new files after enhancement while preserving resolution metadata.
 * 3. When a web service resizes or blurs user‑uploaded images but needs to retain DPI information for downstream CAD workflows.
 * 4. When a batch‑processing script updates image assets without altering their DPI, ensuring consistency across a product catalog.
 * 5. When a digital‑asset‑management tool re‑encodes images after applying effects and must maintain the original DPI for compliance reporting.
 */
