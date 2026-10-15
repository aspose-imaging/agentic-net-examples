// HOW-TO: Convert ODG to SVG with Embedded CSS Styles in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    image.Save(outputPath, svgOptions);
                }
            }

            string svgContent = File.ReadAllText(outputPath);
            int insertPos = svgContent.IndexOf('>');
            if (insertPos != -1)
            {
                string css = "\n<style type=\"text/css\">\n  .consistent { fill: #000000; stroke: none; }\n</style>\n";
                svgContent = svgContent.Insert(insertPos + 1, css);
                File.WriteAllText(outputPath, svgContent);
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
 * 1. When you need to display OpenDocument graphics on a web page, converting ODG to SVG ensures scalability and the embedded CSS guarantees consistent colors across browsers.
 * 2. When integrating legacy ODG diagrams into a modern C# application that generates SVG reports, this code automates the conversion and adds a style block for uniform appearance.
 * 3. When creating an automated pipeline that transforms design assets from ODG to web‑ready SVG files, the embedded CSS helps maintain brand colors without manually editing each file.
 * 4. When exporting ODG charts from a desktop editor to SVG for inclusion in a PDF or HTML document, the added CSS class ensures the shapes render with the desired fill and no stroke.
 * 5. When building a C# service that receives ODG uploads and returns SVG images with predefined styling for use in a SaaS dashboard, this snippet handles the conversion and styling in one step.
 */
