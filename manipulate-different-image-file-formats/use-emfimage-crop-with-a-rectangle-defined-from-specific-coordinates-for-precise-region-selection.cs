// HOW-TO: Crop Specific Region From EMF File Using C# Aspose.Imaging (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        const string inputPath = "input.emf";
        const string outputPath = "output.emf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage image = (EmfImage)Image.Load(inputPath))
            {
                // Define the rectangle region to crop: X, Y, Width, Height
                var cropRect = new Rectangle(50, 50, 300, 200);
                image.Crop(cropRect);
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
 * 1. When you need to extract a logo or diagram from a larger EMF drawing to reuse it in a report.
 * 2. When generating thumbnails of a specific area of an EMF vector graphic for a web preview.
 * 3. When removing unwanted margins from a CAD‑generated EMF file before embedding it into a PDF.
 * 4. When isolating a particular chart region in an EMF file to apply separate styling or annotations.
 * 5. When preparing a precise cutout of a vector illustration for inclusion in a slide deck or marketing material.
 */
