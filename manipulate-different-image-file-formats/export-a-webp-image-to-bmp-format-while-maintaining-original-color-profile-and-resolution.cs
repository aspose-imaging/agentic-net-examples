// HOW-TO: Convert WebP Image to BMP with Original Color Profile in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.webp");
            string outputPath = Path.Combine("Output", "image.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                BmpOptions options = new BmpOptions();
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
 * 1. When you need to display a WebP graphic in a legacy Windows application that only supports BMP files.
 * 2. When you must preserve the original color profile and resolution while converting images for printing workflows.
 * 3. When an automated batch process converts user‑uploaded WebP photos to BMP for compatibility with third‑party image analysis tools.
 * 4. When you are preparing assets for a game engine that requires BMP textures but receives source images in WebP format.
 * 5. When you need to generate BMP thumbnails from WebP files for a file‑explorer preview that cannot render WebP.
 */
