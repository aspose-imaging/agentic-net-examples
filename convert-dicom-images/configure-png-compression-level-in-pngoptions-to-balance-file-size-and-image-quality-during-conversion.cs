// HOW-TO: Set PNG Compression Level When Converting BMP to PNG In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
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
            string inputPath = "input.bmp";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions
                {
                    CompressionLevel = 6 // balanced compression
                };
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
 * 1. When you need to reduce the file size of a PNG generated from a BMP while keeping acceptable image quality in a .NET application.
 * 2. When you are building an image‑processing pipeline that must balance storage constraints and visual fidelity for web‑ready PNG assets.
 * 3. When you want to programmatically control PNG compression during batch conversion of legacy bitmap files to modern formats.
 * 4. When you need to ensure consistent PNG output settings across different environments by specifying the compression level in code.
 * 5. When you are handling user‑uploaded BMP images and must save them as optimized PNGs before storing or displaying them.
 */
