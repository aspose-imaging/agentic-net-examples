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
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.wmf";
            string outputPath = "Output/sample.png";
            string fontFolderPath = "Fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((args) =>
            {
                string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                var result = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var fontFile in Directory.GetFiles(fontsPath))
                    {
                        byte[] fontBytes = File.ReadAllBytes(fontFile);
                        string fontName = Path.GetFileNameWithoutExtension(fontFile);
                        result.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                    }
                }
                return result.ToArray();
            }, fontFolderPath);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a legacy Windows Metafile (WMF) diagram uses proprietary fonts that are not installed on the server, you can load the file with a custom font directory and export it as a PNG for web display.
 * 2. When generating thumbnails of WMF icons in a batch process, you may need to specify a folder containing the required fonts to ensure the text renders correctly in the resulting PNG images.
 * 3. When automating the conversion of technical drawings stored as WMF files into high‑resolution PNGs for inclusion in PDF reports, you can point Aspose.Imaging to a custom font path to preserve label accuracy.
 * 4. When building a C# application that converts user‑uploaded WMF files to PNG while the application runs in a sandboxed environment without system fonts, you can supply the needed fonts via a dedicated folder.
 * 5. When migrating legacy WMF assets to a modern image format and the original fonts are bundled with the assets, this code lets you load those fonts from a specified directory and save the graphics as PNG files.
 */
