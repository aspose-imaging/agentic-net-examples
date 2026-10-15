// HOW-TO: Rotate CMX Vector 90 Degrees Clockwise and Save as EMF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.cmx";
            string outputPath = "output/output.emf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                image.Save(outputPath, new EmfOptions());
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
 * 1. When a CAD application needs to re‑orient a CMX drawing before embedding it into a Windows Metafile for reporting.
 * 2. When a batch conversion tool must rotate legacy CorelDRAW vector files and export them as EMF for compatibility with Microsoft Office.
 * 3. When a GIS system requires rotating map symbols stored in CMX format to match a new north‑up orientation and then save them as EMF for further processing.
 * 4. When an automated document generation pipeline has to adjust the layout of vector graphics and store the result in EMF to preserve scalability.
 * 5. When a developer wants to programmatically rotate a CMX logo 90° clockwise and export it as an EMF image for use in a .NET WinForms UI.
 */
