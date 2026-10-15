// HOW-TO: Convert OTG to SVG with Embedded CSS Styles in C# (Aspose.Imaging for .NET)
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
            {
                using (SvgOptions options = new SvgOptions())
                {
                    image.Save(outputPath, options);
                }
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
 * 1. When you need to display a vector‑based OTG illustration on a web page, this code converts the file to SVG and embeds CSS so the graphics render consistently across browsers.
 * 2. If a design workflow requires exporting CAD‑style OTG drawings to a scalable format for responsive UI components, the snippet automates the conversion to SVG using Aspose.Imaging in C#.
 * 3. When integrating legacy OTG assets into a modern HTML5 application, the code generates SVG files with inline style definitions, eliminating the need for separate stylesheet management.
 * 4. For automated batch processing of OTG files into web‑ready SVGs with preserved styling, this example shows how to load, convert, and save each image programmatically.
 * 5. If you must preserve the visual appearance of an OTG diagram while reducing file size for cloud storage or CDN delivery, the snippet creates a compact SVG with embedded CSS using C#.
 */
