// HOW-TO: Convert WMF to JPEG with Custom Font Directory in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.wmf";
            string outputPath = "Output/sample.jpg";
            string fontDirectory = "Fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new Aspose.Imaging.LoadOptions();
            loadOptions.AddCustomFontSource((object[] args) =>
            {
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (args.Length > 0 && args[0] is string path && !string.IsNullOrEmpty(path) && Directory.Exists(path))
                {
                    foreach (var file in Directory.GetFiles(path))
                    {
                        byte[] data = File.ReadAllBytes(file);
                        string name = Path.GetFileNameWithoutExtension(file);
                        fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                    }
                }
                return fonts.ToArray();
            }, fontDirectory);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath, loadOptions))
            {
                var jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to render legacy WMF vector graphics as high‑quality JPEG images while ensuring the correct fonts are loaded from a specific folder.
 * 2. When generating thumbnails for WMF files in a web application and the required fonts are stored outside the system fonts directory.
 * 3. When batch‑converting a collection of WMF diagrams to JPEG for printing, with corporate custom fonts located in a dedicated Fonts folder.
 * 4. When creating PDF reports that embed JPEG versions of WMF charts and you must load custom TrueType fonts that are not installed on the server.
 * 5. When automating image processing in a CI pipeline that converts WMF assets to JPEG while providing a custom font path to avoid missing‑glyph errors.
 */
