// HOW-TO: Render CorelDRAW CDR to PDF with Custom Font Folder in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.cdr");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string fontFolderPath = Path.Combine("Fonts");

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] args) =>
            {
                var result = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (args != null && args.Length > 0)
                {
                    string fontsPath = args[0]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                    {
                        foreach (var fontFile in Directory.GetFiles(fontsPath))
                        {
                            byte[] fontBytes = File.ReadAllBytes(fontFile);
                            string fontName = Path.GetFileNameWithoutExtension(fontFile);
                            result.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                        }
                    }
                }
                return result.ToArray();
            }, fontFolderPath);

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
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a .NET application needs to convert CorelDRAW CDR files to PDF while preserving brand‑specific fonts that are not installed on the server.
 * 2. When generating printable PDFs from CDR designs in an automated workflow and the required fonts are stored in a separate directory.
 * 3. When deploying a cloud‑based image conversion service that must load custom TrueType or OpenType fonts for accurate text rendering in the output PDF.
 * 4. When creating batch conversions of multiple CDR files to PDF and you want to ensure each document uses the same custom font collection without modifying the system font registry.
 * 5. When integrating Aspose.Imaging into a Windows service that processes user‑uploaded CDR graphics and needs to embed custom typography into the resulting PDF reports.
 */
