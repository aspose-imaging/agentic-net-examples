// HOW-TO: Convert EPS To SVG In C# With Aspose.Imaging (Aspose.Imaging for .NET)
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

namespace EPSConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.eps";
                string outputPath = "output/output.svg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to embed vector graphics from an EPS file into a web page that only supports SVG.
 * 2. When you are automating a batch process that converts legacy EPS artwork to scalable SVG for responsive design.
 * 3. When a design pipeline requires converting printer‑ready EPS files to SVG for further editing in browser‑based tools.
 * 4. When you want to reduce file size by switching from EPS to SVG while preserving vector quality in a .NET application.
 * 5. When integrating Aspose.Imaging into a C# service that receives EPS uploads and returns SVG for downstream processing.
 */
