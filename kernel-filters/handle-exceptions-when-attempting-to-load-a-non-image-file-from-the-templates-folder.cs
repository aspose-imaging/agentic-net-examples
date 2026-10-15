// HOW-TO: How To Handle Loading Non‑Image Files With Aspose.Imaging In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

namespace TiffConcatenationSample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "templates/nonimage.txt";
                string outputPath = "output/result.tiff";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var image = Image.Load(inputPath);
                image.Save(outputPath);
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
 * 1. When you need to verify that a user‑uploaded file is a valid image before converting it to a TIFF document.
 * 2. When a batch job processes files from a templates folder and must skip or report non‑image files without crashing the application.
 * 3. When you want to automatically create the output directory and log an error if the source file is missing or not an image.
 * 4. When integrating Aspose.Imaging into a C# service that concatenates images and must catch exceptions from unsupported formats such as .txt files.
 * 5. When building a robust image‑processing pipeline that gracefully handles corrupted or wrong‑type files and provides clear error messages.
 */
