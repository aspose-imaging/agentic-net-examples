using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.cdr";
            string outputPath = "output.pdf";
            string fontFolderPath = "fonts";

            // Input file validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load options with custom font source
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(
                args =>
                {
                    string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                    var customFonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (Directory.Exists(fontsPath))
                    {
                        foreach (var file in Directory.GetFiles(fontsPath))
                        {
                            var fontData = File.ReadAllBytes(file);
                            var fontName = Path.GetFileNameWithoutExtension(file);
                            customFonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontData));
                        }
                    }
                    return customFonts.ToArray();
                },
                fontFolderPath);

            // Load CDR image with custom fonts
            using (var image = Image.Load(inputPath, loadOptions))
            {
                // Configure vector rasterization options
                var vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument,
                    BackgroundColor = Color.White
                };

                // Prepare PDF options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save as PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert CorelDRAW (CDR) files that use corporate brand fonts stored in a private fonts directory into PDF for distribution, they can register the custom font folder to preserve typography.
 * 2. When an automated document processing pipeline must generate PDF invoices from CDR templates that rely on licensed fonts not installed on the server, registering a custom font source ensures the correct font rendering.
 * 3. When a cloud‑based design review tool imports user‑uploaded CDR artwork containing custom typography and exports it as PDF for browser preview, the code registers the user’s font folder to avoid missing‑glyph issues.
 * 4. When a batch conversion utility processes a large collection of legacy CDR marketing assets that reference archived fonts located in a network share, adding the custom font folder guarantees accurate visual fidelity in the resulting PDFs.
 * 5. When a print‑ready publishing workflow converts CDR layouts to PDF for high‑resolution printing and must embed specific OpenType fonts that are not installed on the build machine, registering the custom font directory ensures the fonts are embedded correctly.
 */