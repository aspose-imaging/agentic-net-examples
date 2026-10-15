// HOW-TO: Convert OTG to SVG and Minify XML Output in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            using (SvgOptions svgOptions = new SvgOptions())
            {
                image.Save(outputPath, svgOptions);
            }

            string xml = File.ReadAllText(outputPath);
            xml = xml.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            while (xml.Contains("  "))
            {
                xml = xml.Replace("  ", " ");
            }
            File.WriteAllText(outputPath, xml);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed vector graphics from an OTG design into a web page and want a lightweight SVG file.
 * 2. When you are building a batch conversion tool that transforms legacy OTG assets to SVG for cross‑platform compatibility.
 * 3. When you want to reduce the size of generated SVG files to improve page load speed in a C# web application.
 * 4. When you need to programmatically convert OTG diagrams to SVG for further processing or editing in vector editors.
 * 5. When you are automating the preparation of SVG assets for mobile apps and must remove unnecessary whitespace from the XML.
 */
