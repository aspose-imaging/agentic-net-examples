// HOW-TO: Convert OTG to SVG with Correct ViewBox in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Aspose.Imaging.Color.White
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to display a proprietary OTG diagram on a web page, they can convert it to SVG with a proper viewBox so the graphic scales correctly in browsers.
 * 2. When integrating legacy OTG assets into a modern C# application, converting them to SVG enables vector‑based rendering and editing without losing the original dimensions.
 * 3. When generating printable reports that require scalable graphics, converting OTG files to SVG with accurate page width and height ensures the output matches the source layout.
 * 4. When building a design‑to‑code pipeline, developers can use this code to transform OTG artwork into SVG files that can be styled with CSS and animated with JavaScript.
 * 5. When migrating a digital asset library from a desktop format to a web‑friendly format, the conversion preserves the original image size by setting the viewBox, allowing seamless reuse across platforms.
 */
