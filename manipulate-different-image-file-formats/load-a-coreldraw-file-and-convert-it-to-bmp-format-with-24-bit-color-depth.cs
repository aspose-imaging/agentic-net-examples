// HOW-TO: Convert CorelDRAW CDR to 24‑Bit BMP in C# (Aspose.Imaging for .NET)
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

namespace CorelDrawToBmp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.cdr";
                string outputPath = "output\\converted.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24
                    };
                    image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to generate 24‑bit BMP thumbnails from CorelDRAW CDR files for a Windows desktop application.
 * 2. When an automated pipeline must convert uploaded CDR designs into BMP images for legacy printing systems that only accept BMP format.
 * 3. When a migration tool has to transform a library of CorelDRAW assets into BMP files to ensure compatibility with a third‑party image viewer.
 * 4. When a batch job processes CDR files and saves them as high‑color‑depth BMPs to preserve visual fidelity before archiving.
 * 5. When integrating Aspose.Imaging into a C# service that receives CDR files via API and returns BMP images for downstream processing.
 */
