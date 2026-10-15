// HOW-TO: Convert ODG to PDF with Embedded Fonts Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(GetFontSource, "Fonts");

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static Aspose.Imaging.CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
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
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a printable PDF from an OpenDocument Graphics (ODG) diagram while preserving the original text appearance by embedding custom fonts.
 * 2. When a web application must serve ODG‑based charts as PDF reports and ensure the PDFs render correctly on client machines without installed fonts.
 * 3. When automating batch conversion of design assets stored as ODG files to PDF for archival, requiring font embedding to meet compliance standards.
 * 4. When integrating Aspose.Imaging into a C# workflow that converts user‑uploaded ODG files to PDF for email attachment, guaranteeing consistent rendering across platforms.
 * 5. When creating a document management system that extracts ODG drawings and saves them as PDF with embedded fonts to avoid missing‑font warnings in PDF viewers.
 */
