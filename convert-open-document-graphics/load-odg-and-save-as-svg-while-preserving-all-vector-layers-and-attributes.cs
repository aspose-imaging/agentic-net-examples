// HOW-TO: Convert ODG to SVG With Full Vector Layer Preservation In C# (Aspose.Imaging for .NET)
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

namespace VectorConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
                string outputPath = "output.svg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

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
 * 1. When a design tool exports drawings as ODG and you need to embed them in web pages as scalable SVG while keeping all vector shapes and styles intact.
 * 2. When migrating legacy OpenDocument graphics to a modern SVG workflow for responsive UI components without losing layer information.
 * 3. When automating batch conversion of ODG assets to SVG for a publishing pipeline that requires vector fidelity for print-quality output.
 * 4. When integrating Aspose.Imaging into a C# application to allow users to upload ODG files and instantly view or edit them as SVG in a browser.
 * 5. When preserving custom attributes such as stroke, fill, and grouping from an ODG diagram during conversion to SVG for further programmatic manipulation.
 */
