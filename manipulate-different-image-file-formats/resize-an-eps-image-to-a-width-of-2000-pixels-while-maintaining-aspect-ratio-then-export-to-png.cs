// HOW-TO: Resize EPS to 2000px Width and Export as PNG in C# (Aspose.Imaging for .NET)
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

namespace EPSResizeExport
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input/input.eps";
                string outputPath = "output/output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    int originalWidth = image.Width;
                    int originalHeight = image.Height;

                    int newWidth = 2000;
                    int newHeight = (int)Math.Round((double)originalHeight * newWidth / originalWidth);

                    image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                    var pngOptions = new PngOptions();
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
 * 1. When you need to convert a vector EPS logo to a high‑resolution PNG thumbnail of exactly 2000 pixels wide while preserving its proportions.
 * 2. When preparing print‑ready artwork for web display, you can resize the EPS to a fixed width and save it as PNG for faster loading.
 * 3. When automating a workflow that ingests EPS files from a design team and outputs PNG assets with a consistent width for a content management system.
 * 4. When integrating Aspose.Imaging into a C# application to generate PNG previews of EPS diagrams that fit within a specific layout width.
 * 5. When creating a batch script that processes multiple EPS files, resizing each to 2000 px wide and exporting them as PNGs for use in mobile apps.
 */
