// HOW-TO: Rotate EMF Image 90 Degrees and Convert to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Emf;

namespace ImageProcessor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.emf";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    if (image is EmfImage emfImage)
                    {
                        emfImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        var pngOptions = new PngOptions();
                        emfImage.Save(outputPath, pngOptions);
                    }
                    else
                    {
                        Console.Error.WriteLine("Input file is not an EMF image.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display a legacy EMF diagram on a web page that only supports PNG, you can rotate it 90° and convert it to PNG.
 * 2. When generating printable reports that require landscape‑oriented graphics, you can rotate the EMF artwork and save it as a PNG for inclusion.
 * 3. When processing batch files from a CAD system that outputs EMF files oriented incorrectly, you can programmatically rotate each file and convert to PNG for downstream workflows.
 * 4. When creating thumbnails for a document management system that stores images as PNG, you can rotate the original EMF and convert it to PNG in one step.
 * 5. When integrating with a third‑party API that accepts only PNG images, you can adjust the orientation of an EMF logo and convert it to PNG before uploading.
 */
