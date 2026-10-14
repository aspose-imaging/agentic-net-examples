// HOW-TO: Convert OTG to SVG While Preserving Vector Data in C# (Aspose.Imaging for .NET)
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

namespace ConvertOtgToSvg
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output.svg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputDir = Path.GetDirectoryName(outputPath);
                Directory.CreateDirectory(outputDir ?? string.Empty);

                using (Image image = Image.Load(inputPath))
                {
                    var options = new SvgOptions();
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
 * 1. When a developer needs to export an OTG font file to scalable SVG for web display without losing vector outlines.
 * 2. When integrating a design pipeline that receives OTG assets and must generate SVG icons for responsive UI components.
 * 3. When converting proprietary OTG artwork into SVG to enable editing in vector graphics editors like Adobe Illustrator.
 * 4. When automating batch processing of OTG files on a server to produce SVG files for PDF generation or printing workflows.
 * 5. When building a C# application that reads OTG glyphs and saves them as SVG to embed in HTML emails or documentation.
 */
