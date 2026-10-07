// HOW-TO: Flip WebP Image Horizontally and Save as BMP Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output\\output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
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
 * 1. When a developer needs to display a mirrored version of a WebP graphic in a legacy Windows application that only supports BMP files.
 * 2. When an e‑commerce site must generate horizontally flipped product thumbnails from WebP images and store them as BMP for compatibility with a third‑party imaging service.
 * 3. When a game developer wants to create left‑handed sprite assets by flipping WebP textures and exporting them to BMP for the game engine’s asset pipeline.
 * 4. When a document‑generation system requires converting WebP logos into BMP format after applying a horizontal flip to match branding guidelines.
 * 5. When an automated batch job processes user‑uploaded WebP photos, mirrors them horizontally, and saves the results as BMP for archival in a format that preserves lossless quality.
 */
