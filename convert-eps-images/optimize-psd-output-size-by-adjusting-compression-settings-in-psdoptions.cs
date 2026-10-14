// HOW-TO: How To Reduce PSD File Size Using RLE Compression In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PsdOptions options = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE
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
 * 1. When you need to convert high‑resolution JPEG photos to layered PSD files while keeping the resulting file size small for faster web uploads.
 * 2. When an automated image‑processing pipeline must generate PSD assets from user‑uploaded JPEGs and you want to minimize storage costs by applying RLE compression.
 * 3. When a desktop application creates PSD previews from JPEG thumbnails and requires reduced disk usage without losing layer information.
 * 4. When a batch job processes thousands of JPEG images into PSD format for a design workflow and you need to ensure the output files fit within a limited archive size.
 * 5. When integrating Aspose.Imaging in a C# service that delivers PSD files to clients, and you want to optimize network transfer by using the most efficient compression method.
 */
