// HOW-TO: Batch Convert WMF Files to JPEG with Custom Font Folder in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");
            string fontFolder = Path.Combine(baseDir, "Fonts");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            if (!Directory.Exists(fontFolder))
            {
                Directory.CreateDirectory(fontFolder);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.wmf");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.ChangeExtension(Path.GetFileName(inputPath), ".jpg"));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new LoadOptions();
                loadOptions.AddCustomFontSource(args =>
                {
                    var result = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (args != null && args.Length > 0 && args[0] is string fontsPath && Directory.Exists(fontsPath))
                    {
                        foreach (var fontFile in Directory.GetFiles(fontsPath))
                        {
                            byte[] fontBytes = File.ReadAllBytes(fontFile);
                            string fontName = Path.GetFileNameWithoutExtension(fontFile);
                            result.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                        }
                    }
                    return result.ToArray();
                }, fontFolder);

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    var jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to automatically convert a large collection of legacy WMF vector drawings into JPEG images for web display while ensuring the correct fonts are used.
 * 2. When your application must process WMF files stored in a specific input folder and output JPEGs to another folder without manual intervention.
 * 3. When the WMF files reference custom TrueType fonts that are not installed on the system, and you need to point Aspose.Imaging to a custom font directory.
 * 4. When you want to integrate a batch image conversion step into a build or deployment pipeline that prepares assets for mobile or desktop applications.
 * 5. When you are building a document‑to‑image service that receives WMF uploads, applies corporate fonts, and returns JPEG thumbnails for preview.
 */
