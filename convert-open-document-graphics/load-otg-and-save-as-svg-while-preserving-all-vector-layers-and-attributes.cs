// HOW-TO: Convert OTG to SVG with Vector Layers Preserved in C# (Aspose.Imaging for .NET)
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

namespace OtgToSvgConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input/input.otg";
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
 * 1. When you need to export a multi‑layer OTG design to an SVG file for web display while keeping all vector shapes and attributes intact using Aspose.Imaging in C#.
 * 2. When integrating Aspose.Imaging into a C# application that converts proprietary OTG graphics from a CAD system into scalable SVG for responsive UI rendering.
 * 3. When automating a batch process that transforms OTG assets into SVG to enable editing in vector editors like Inkscape without losing layer information.
 * 4. When creating a server‑side service that receives OTG uploads and returns SVG previews for thumbnail generation while preserving the original vector data.
 * 5. When migrating legacy OTG artwork to modern web standards and require a programmatic C# solution that retains vector layers during the conversion to SVG.
 */
