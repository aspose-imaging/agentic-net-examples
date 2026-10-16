// HOW-TO: Convert EPS to PSD with RLE Compression Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\result.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image epsImage = Image.Load(inputPath))
            {
                using (PsdOptions options = new PsdOptions())
                {
                    options.CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE;
                    epsImage.Save(outputPath, options);
                }
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
 * 1. When you need to import vector EPS artwork into Photoshop while keeping file size low by applying RLE compression.
 * 2. When an automated pipeline must batch‑convert EPS logos to layered PSD files for further editing in .NET applications.
 * 3. When a web service generates printable designs in EPS and must deliver them as PSDs with lossless compression for client workflows.
 * 4. When migrating legacy EPS assets to PSD format in a Windows environment using C# and Aspose.Imaging to preserve image quality.
 * 5. When creating a desktop utility that reads EPS files and saves them as PSDs with customizable compression settings for storage optimization.
 */
