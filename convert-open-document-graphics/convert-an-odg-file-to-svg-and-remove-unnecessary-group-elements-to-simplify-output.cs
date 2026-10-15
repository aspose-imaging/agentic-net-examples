// HOW-TO: Convert ODG to SVG and Strip Group Tags in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
                image.Save(outputPath, options);
            }

            string svgContent = File.ReadAllText(outputPath);
            svgContent = Regex.Replace(svgContent, @"<g[^>]*>", "", RegexOptions.IgnoreCase);
            svgContent = Regex.Replace(svgContent, @"</g>", "", RegexOptions.IgnoreCase);
            File.WriteAllText(outputPath, svgContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed an OpenDocument graphic into a web page, you can convert the .odg file to lightweight SVG and remove unnecessary <g> containers for faster rendering.
 * 2. When preparing vector assets for responsive design, you may convert ODG drawings to SVG and clean up group tags to reduce file size and simplify DOM manipulation.
 * 3. When integrating legacy ODG diagrams into a C# application that generates reports, you can use Aspose.Imaging to transform them into SVG and strip grouping elements for easier styling with CSS.
 * 4. When automating batch processing of design files, this code lets you programmatically convert multiple .odg files to clean SVG files without manual editing.
 * 5. When optimizing SVG output for mobile devices, removing group elements after conversion from ODG helps improve performance and reduces parsing overhead in browsers.
 */
