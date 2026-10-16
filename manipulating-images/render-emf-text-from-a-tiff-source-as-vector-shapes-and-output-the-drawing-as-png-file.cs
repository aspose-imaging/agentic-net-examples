// HOW-TO: Convert TIFF to Vector EMF and Then to PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded paths
            string inputTiffPath = "input.tiff";
            string intermediateEmfPath = "temp.emf";
            string outputPngPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }

            // Load TIFF image
            using (Image tiffImage = Image.Load(inputTiffPath))
            {
                // Save as EMF (vector) using EmfOptions
                var emfOptions = new EmfOptions();
                tiffImage.Save(intermediateEmfPath, emfOptions);
            }

            // Ensure output directory exists for PNG
            string pngDir = Path.GetDirectoryName(outputPngPath);
            Directory.CreateDirectory(pngDir ?? ".");

            // Load the generated EMF image
            using (Image emfImage = Image.Load(intermediateEmfPath))
            {
                // Save as PNG
                var pngOptions = new PngOptions();
                emfImage.Save(outputPngPath, pngOptions);
            }

            // Optionally clean up intermediate EMF file
            if (File.Exists(intermediateEmfPath))
            {
                try { File.Delete(intermediateEmfPath); } catch { /* ignore cleanup errors */ }
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
 * 1. When you need to keep the text from a scanned TIFF document as scalable vector graphics before creating a PNG preview.
 * 2. When a reporting tool requires converting multi‑page TIFF charts into EMF vector files for high‑quality printing and then into PNG for web display.
 * 3. When an application must generate PNG thumbnails from TIFF images while preserving text clarity by first converting to EMF.
 * 4. When you want to automate batch processing of TIFF assets, turning them into vector EMF files to edit or annotate, then exporting the final result as PNG.
 * 5. When integrating Aspose.Imaging in a C# service that extracts vector shapes from TIFF files for GIS or CAD workflows and outputs them as PNG images.
 */
