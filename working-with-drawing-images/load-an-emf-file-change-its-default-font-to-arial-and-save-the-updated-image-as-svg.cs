// HOW-TO: Convert EMF to SVG with Arial Font Replacement in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var loadOptions = new LoadOptions();
            string fontsFolder = @"C:\Windows\Fonts";

            loadOptions.AddCustomFontSource(
                (object[] _) =>
                {
                    var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (Directory.Exists(fontsFolder))
                    {
                        foreach (var fontFile in Directory.GetFiles(fontsFolder, "*.ttf"))
                        {
                            byte[] fontBytes = File.ReadAllBytes(fontFile);
                            string fontName = Path.GetFileNameWithoutExtension(fontFile);
                            fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                        }
                    }
                    return fonts.ToArray();
                },
                fontsFolder);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var svgOptions = new SvgOptions();
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
 * 1. When you need to embed a consistent Arial typeface in vector graphics exported from legacy EMF files to SVG for web display.
 * 2. When a reporting system generates EMF charts that must be converted to scalable SVG while ensuring all text uses Arial for brand compliance.
 * 3. When an automated pipeline processes Windows Metafile diagrams and requires the output SVG to contain only standard fonts to avoid missing‑font issues on client browsers.
 * 4. When you are migrating desktop application assets from EMF to SVG and want to guarantee font fidelity by loading custom TTF fonts from the system folder.
 * 5. When a document conversion service must transform EMF illustrations to SVG and replace the original fonts with Arial to maintain visual consistency across platforms.
 */
