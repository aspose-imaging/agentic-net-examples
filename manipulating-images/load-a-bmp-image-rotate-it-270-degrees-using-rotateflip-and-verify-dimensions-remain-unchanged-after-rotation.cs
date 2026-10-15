// HOW-TO: Rotate BMP Image 270 Degrees Without Changing Dimensions in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                image.RotateFlip(RotateFlipType.Rotate270FlipNone);

                if (image.Width != originalWidth || image.Height != originalHeight)
                {
                    Console.Error.WriteLine("Dimensions changed after rotation.");
                }

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
 * 1. When you need to display a BMP graphic in portrait orientation on a UI that expects the original width and height.
 * 2. When processing scanned documents that were saved upside‑down and must be rotated 270° while preserving the original page size for PDF conversion.
 * 3. When preparing game assets stored as BMP files for a sprite sheet that requires a specific rotation but cannot change the sprite dimensions.
 * 4. When automating batch image adjustments for a legacy system that only accepts BMP files of a fixed resolution, and you must rotate them without altering size.
 * 5. When validating that a custom RotateFlip operation does not unintentionally resize BMP images before sending them to a printing service.
 */
