// HOW-TO: Convert ODG to SVG and Minify XML with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "Input", "sample.odg");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Output", "sample.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new SvgOptions();
                image.Save(outputPath, options);
            }

            string xml = File.ReadAllText(outputPath);
            string minified = xml.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("  ", " ");
            while (minified.Contains("  "))
            {
                minified = minified.Replace("  ", " ");
            }
            minified = minified.Replace("> <", "><").Trim();
            File.WriteAllText(outputPath, minified);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed an OpenDocument graphic in a web page and want a lightweight SVG file.
 * 2. When you are building a batch conversion tool that transforms ODG drawings to SVG for cross‑platform compatibility.
 * 3. When you must reduce the size of generated SVG files to improve page load speed in a web application.
 * 4. When you want to automate the conversion of design assets from ODG to SVG as part of a CI/CD pipeline.
 * 5. When you need to programmatically clean up SVG markup after conversion to meet strict bandwidth or storage constraints.
 */
