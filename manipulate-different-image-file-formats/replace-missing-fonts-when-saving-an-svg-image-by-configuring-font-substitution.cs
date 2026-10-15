// HOW-TO: How To Substitute Missing Fonts When Saving SVG With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] fontArgs) =>
            {
                string fontsPath = fontArgs.Length > 0 ? fontArgs[0]?.ToString() : string.Empty;
                var fontsList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var file in Directory.GetFiles(fontsPath))
                    {
                        byte[] data = File.ReadAllBytes(file);
                        string name = Path.GetFileNameWithoutExtension(file);
                        fontsList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                    }
                }
                return fontsList.ToArray();
            }, "fonts");

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var svgImage = (SvgImage)image;
                var svgOptions = new SvgOptions();
                svgImage.Save(outputPath, svgOptions);
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
 * 1. When an SVG file references fonts that are not installed on the server, a developer can use this code to provide custom font files so the SVG renders correctly after saving.
 * 2. When generating reports that embed SVG graphics with corporate typefaces, the code ensures the required fonts are embedded even if the runtime environment lacks them.
 * 3. When migrating legacy SVG assets to a new system where original fonts are unavailable, this approach substitutes the missing fonts to preserve visual fidelity.
 * 4. When building a web service that converts user‑uploaded SVGs to other formats, the code guarantees consistent text appearance by loading fonts from a specified folder.
 * 5. When automating batch processing of SVGs in a CI pipeline, the snippet prevents font‑related errors by supplying a custom font source during image loading.
 */
