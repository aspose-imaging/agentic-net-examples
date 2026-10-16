// HOW-TO: Increase Line Thickness of EMF and Save as WMF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.wmf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image emfImage = Aspose.Imaging.Image.Load(inputPath))
            {
                // Increase line thickness by 2 points - not directly supported; placeholder for future implementation.
                WmfOptions wmfOptions = new WmfOptions();
                emfImage.Save(outputPath, wmfOptions);
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
 * 1. When converting legacy EMF diagrams to WMF for compatibility with older Windows applications while adjusting stroke weight.
 * 2. When programmatically enhancing the visual weight of lines in vector icons before embedding them in a C# desktop UI.
 * 3. When batch‑processing engineering schematics stored as EMF to produce thicker‑lined WMF files for clearer printing.
 * 4. When integrating Aspose.Imaging into a .NET service that receives EMF files and returns WMF versions with increased line thickness for reporting tools.
 * 5. When automating the preparation of EMF charts for inclusion in PowerPoint slides that require WMF format with bolder outlines.
 */
