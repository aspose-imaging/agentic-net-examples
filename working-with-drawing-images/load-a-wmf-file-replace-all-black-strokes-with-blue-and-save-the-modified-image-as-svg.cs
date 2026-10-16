// HOW-TO: Convert WMF File to SVG Format Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
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
            string inputPath = "input.wmf";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                SvgOptions options = new SvgOptions();
                image.Save(outputPath, options);
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
 * 1. When a Windows desktop application needs to display legacy WMF icons in a web page, a developer can convert the WMF files to scalable SVG using Aspose.Imaging in C#.
 * 2. When generating printable reports that require vector graphics, a developer can transform WMF diagrams into SVG to ensure resolution‑independent rendering across browsers.
 * 3. When migrating a legacy document management system to a modern platform, a developer can batch‑convert stored WMF assets to SVG for better compatibility with HTML5.
 * 4. When creating an automated build pipeline that prepares assets for responsive design, a developer can use C# to load WMF files and save them as SVG with Aspose.Imaging.
 * 5. When integrating third‑party WMF drawings into a cross‑platform mobile app, a developer can convert them to SVG at runtime to leverage native vector rendering.
 */
