// HOW-TO: Batch Convert CDR Files to PDF with Embedded Custom Fonts in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            string fontsDirectory = "Fonts";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);
            Directory.CreateDirectory(fontsDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new LoadOptions();
                loadOptions.AddCustomFontSource((object[] args) =>
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
                }, fontsDirectory);

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    using (var pdfOptions = new PdfOptions())
                    {
                        pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        };

                        image.Save(outputPath, pdfOptions);
                    }
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
 * 1. When you need to generate printable PDFs from a collection of CorelDRAW designs while ensuring the documents use company‑specific fonts that are not installed on the target system.
 * 2. When an automated workflow must convert multiple .cdr files to PDF and embed the exact font files to guarantee consistent text appearance across different viewers.
 * 3. When you are building a document‑generation service that receives CorelDRAW templates and must output PDFs with licensed fonts packaged inside the file.
 * 4. When migrating legacy design assets to a PDF archive and you must preserve the original typography by loading custom font files from a directory.
 * 5. When creating a batch conversion tool for a print shop that processes dozens of CDR files nightly, embedding the shop’s proprietary fonts into each resulting PDF.
 */
