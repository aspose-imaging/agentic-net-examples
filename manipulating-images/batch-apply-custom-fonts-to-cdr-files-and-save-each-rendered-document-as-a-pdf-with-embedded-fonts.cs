// HOW-TO: Batch Convert CDR Files to PDF with Custom Embedded Fonts in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputFolder = "C:\\InputCdr";
            string outputFolder = "C:\\OutputPdf";
            string fontsFolder = "C:\\CustomFonts";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all CDR files
            string[] cdrFiles = Directory.GetFiles(inputFolder, "*.cdr");

            foreach (var cdrPath in cdrFiles)
            {
                if (!File.Exists(cdrPath))
                {
                    Console.Error.WriteLine($"File not found: {cdrPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(cdrPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".pdf");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new Aspose.Imaging.LoadOptions();
                loadOptions.AddCustomFontSource(GetFontSource, fontsFolder);

                using (var image = Aspose.Imaging.Image.Load(cdrPath, loadOptions) as CdrImage)
                {
                    var pdfOptions = new PdfOptions();
                    var rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    image.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static Aspose.Imaging.CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = string.Empty;
        if (args.Length > 0)
        {
            fontsPath = args[0]?.ToString() ?? string.Empty;
        }

        var customFontData = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
        if (Directory.Exists(fontsPath))
        {
            foreach (var fontFile in Directory.GetFiles(fontsPath))
            {
                string fontName = Path.GetFileNameWithoutExtension(fontFile);
                byte[] fontBytes = File.ReadAllBytes(fontFile);
                customFontData.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
            }
        }

        return customFontData.ToArray();
    }
}

/*
 * Real-World Use Cases:
 * 1. When a design studio needs to generate printable PDFs from multiple CorelDRAW (CDR) assets while applying company‑specific fonts that are not installed on the rendering machine.
 * 2. When an automated build pipeline must convert a folder of CDR illustrations into PDF documents with the correct typography for downstream publishing.
 * 3. When a web service processes user‑uploaded CDR files and returns PDF previews that preserve the original text appearance using custom font files.
 * 4. When a document management system migrates legacy CDR drawings to PDF format and must embed the required fonts to ensure consistent viewing on any device.
 * 5. When a batch script needs to render CDR graphics with precise text rendering settings and output PDF files that include the embedded custom fonts for archival compliance.
 */
