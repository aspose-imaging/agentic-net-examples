// HOW-TO: Convert OTG to JPEG With 85% Quality In C# (Aspose.Imaging for .NET)
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

namespace OtgToJpegConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 85
                    };
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate web‑ready JPEG thumbnails from OTG design files in a C# desktop application.
 * 2. When a server‑side service must convert uploaded OTG images to compressed JPEGs with a specific quality setting for storage optimization.
 * 3. When automating a migration of legacy OTG assets to JPEG format while preserving visual fidelity by controlling the compression level.
 * 4. When integrating Aspose.Imaging into a C# batch script that processes multiple OTG files and outputs JPEGs with 85 % quality for printing workflows.
 * 5. When building a C# utility that validates the existence of OTG files, creates output directories, and saves them as JPEGs with a predefined quality for downstream image analysis.
 */
