// HOW-TO: Convert WMF to PNG with Custom Font Folder in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
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
            string inputPath = Path.Combine("Input", "sample.wmf");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string customFontFolder = Path.Combine("Fonts");
            FontSettings.SetFontsFolders(new string[] { customFontFolder }, true);

            using (var image = Image.Load(inputPath))
            {
                var options = new PngOptions();
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
 * 1. When an application must render legacy WMF diagrams that use proprietary fonts, you can point Aspose.Imaging to a custom font folder and export them as PNG images.
 * 2. If a reporting tool generates WMF charts on a server without the required fonts installed, this code ensures the charts are rasterized correctly to PNG by loading the fonts from a specified directory.
 * 3. When automating batch conversion of WMF files to web‑friendly PNGs in a CI pipeline, you may need to supply custom fonts to preserve text appearance.
 * 4. For a document conversion service that receives WMF files containing brand‑specific typefaces, setting FontSettings lets you maintain branding when converting to PNG.
 * 5. In a desktop utility that allows users to preview WMF graphics with their own font collections, this snippet loads the custom fonts before saving the preview as a PNG image.
 */
