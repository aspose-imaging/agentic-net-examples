// HOW-TO: Rotate WebP Image 90 Degrees And Save As BMP In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.webp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                var bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to display a WebP graphic in a legacy Windows application that only supports BMP, you can rotate it and convert it to BMP.
 * 2. When processing user‑uploaded WebP photos taken in portrait mode, you may rotate them 90° before saving as BMP for further analysis.
 * 3. When generating thumbnails for a reporting tool that requires BMP files, you can rotate the source WebP and export it in one step.
 * 4. When integrating with a third‑party system that expects BMP images oriented correctly, you can use this code to re‑orient and convert WebP assets.
 * 5. When automating batch image preparation for printing where BMP is the required format, rotating the WebP ensures the final output matches the page layout.
 */
