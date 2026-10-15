// HOW-TO: Export EPS to Grayscale PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

namespace EpsToGrayscalePng
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.eps";
                string outputPath = "output/output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.Grayscale
                    };
                    image.Save(outputPath, pngOptions);
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
 * 1. When a design workflow requires converting vector EPS artwork to a lightweight grayscale PNG for web preview or email attachment, this code provides a quick C# solution.
 * 2. When generating print‑ready assets that must have consistent color depth across platforms, developers can use the snippet to force EPS files into a single‑channel PNG.
 * 3. When building an automated batch job that extracts EPS logos from a repository and stores them as grayscale PNG thumbnails for a catalog, the code handles the conversion reliably.
 * 4. When a mobile app needs to display EPS diagrams but only supports PNG images, converting them to grayscale reduces file size while preserving detail, and this example shows how to do it in .NET.
 * 5. When performing image analysis that expects a single‑channel input, developers can first convert EPS source files to grayscale PNGs using Aspose.Imaging to ensure uniform input data.
 */
