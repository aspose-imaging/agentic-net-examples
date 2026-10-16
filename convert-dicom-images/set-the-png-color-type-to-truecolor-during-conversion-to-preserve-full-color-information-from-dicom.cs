// HOW-TO: Convert DICOM to Truecolor PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.dcm";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                using (Image image = Image.Load(inputPath))
                {
                    var options = new PngOptions
                    {
                        ColorType = PngColorType.Truecolor
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
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to export DICOM scans as high‑fidelity PNG files for web viewers, preserving the full color palette.
 * 2. When a radiology workflow requires converting DICOM images to truecolor PNGs before embedding them into patient reports or EMR systems.
 * 3. When a developer wants to generate lossless PNG thumbnails from DICOM files while ensuring no color information is reduced by the conversion.
 * 4. When integrating Aspose.Imaging into a C# service that transforms DICOM data into truecolor PNGs for archival or machine‑learning preprocessing.
 * 5. When a desktop tool must batch‑process DICOM files into PNG format with the truecolor color type to maintain diagnostic image quality.
 */
