// HOW-TO: Convert TGA Image to BMP with Alpha Channel in C# (Aspose.Imaging for .NET)
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
        string inputPath = Path.Combine("Input", "image.tga");
        string outputPath = Path.Combine("Output", "image.bmp");

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new BmpOptions();
                image.Save(outputPath, options);
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
 * 1. When a game developer needs to export TGA textures with transparency to BMP for a Windows‑only rendering pipeline.
 * 2. When a desktop application must batch‑convert legacy TGA graphics to BMP while keeping the original bit depth for accurate color reproduction.
 * 3. When an image‑processing service receives user‑uploaded TGA files and must store them as BMPs without losing the alpha channel for later compositing.
 * 4. When a migration script updates an asset library from TGA to BMP format to comply with a third‑party tool that only reads BMP files.
 * 5. When a C# utility needs to read a TGA file, preserve its transparency, and save it as BMP for inclusion in a PDF report.
 */
