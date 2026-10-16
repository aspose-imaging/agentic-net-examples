// HOW-TO: Rotate A TIFF Image 90 Degrees And Save As BMP In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input/input.tif";
            string outputPath = "output/output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                image.Save(outputPath, new BmpOptions());
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
 * 1. When you need to rotate a scanned TIFF page 90° clockwise and store it as a BMP file for a legacy Windows application that only supports BMP format.
 * 2. When processing batch TIFF images from a scanner, you must reorient each image and convert it to BMP before feeding them into a third‑party OCR engine that requires BMP input.
 * 3. When preparing graphics for a game that uses BMP sprites, you may rotate the original TIFF artwork and save it as BMP using Aspose.Imaging in C#.
 * 4. When integrating with an older reporting system that expects BMP images, you can rotate incoming TIFF charts and convert them to BMP on the fly.
 * 5. When automating document archiving, you might need to correct the orientation of TIFF files and convert them to BMP for compatibility with a storage service that only accepts BMP files.
 */
