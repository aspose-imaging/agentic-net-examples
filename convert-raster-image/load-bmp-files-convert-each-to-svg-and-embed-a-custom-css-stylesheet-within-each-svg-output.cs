// HOW-TO: Convert BMP to SVG with Embedded CSS Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = ".";
            Directory.CreateDirectory(outputDir);

            // Load BMP and convert to SVG
            using (Image image = Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
            }

            // Embed custom CSS stylesheet into the SVG
            string cssContent = @"
                /* Custom CSS */
                svg { background-color: #ffffff; }
                path { stroke: #000000; stroke-width: 1; }
            ";

            string svgText = File.ReadAllText(outputPath);
            int insertPos = svgText.IndexOf('>');
            if (insertPos != -1)
            {
                string styleElement = $"<style type=\"text/css\"><![CDATA[{cssContent}]]></style>";
                svgText = svgText.Insert(insertPos + 1, styleElement);
                File.WriteAllText(outputPath, svgText);
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
 * 1. When you need to generate scalable vector graphics from legacy BMP assets and apply a custom style sheet for consistent branding in a C# web application.
 * 2. When automating batch conversion of raster images to SVG for responsive UI designs while embedding CSS to control colors and stroke widths.
 * 3. When preparing printable diagrams from BMP files and want the SVG output to include CSS that sets background and line styles without editing the file manually.
 * 4. When integrating image conversion into a .NET service that supplies SVG icons with predefined styling for use in client‑side JavaScript visualizations.
 * 5. When migrating a desktop application’s bitmap icons to vector format and need to embed CSS directly in the SVG to ensure proper rendering across different browsers.
 */
