// HOW-TO: Check WebP File Exists Before Converting to PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions();
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
 * 1. When an application processes user‑uploaded WebP images and must ensure the file is present before converting it to PNG to avoid runtime errors.
 * 2. When a batch job converts a folder of WebP assets to PNG for compatibility with browsers that do not support WebP.
 * 3. When a server‑side service validates image paths before transformation to prevent FileNotFound exceptions in a .NET microservice.
 * 4. When a desktop utility needs to create the output directory automatically while converting WebP screenshots to PNG format.
 * 5. When developers want to handle missing source images gracefully using Aspose.Imaging in a C# image‑processing pipeline.
 */
