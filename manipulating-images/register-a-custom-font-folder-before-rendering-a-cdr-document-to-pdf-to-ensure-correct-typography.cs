using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.pdf";
            string fontFolderPath = "Fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] args) =>
            {
                string fontsPath = string.Empty;
                if (args.Length > 0 && args[0] != null)
                {
                    fontsPath = args[0].ToString();
                }

                var list = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (Directory.Exists(fontsPath))
                {
                    foreach (var fontFile in Directory.GetFiles(fontsPath))
                    {
                        string fontName = Path.GetFileNameWithoutExtension(fontFile);
                        byte[] fontBytes = File.ReadAllBytes(fontFile);
                        list.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                    }
                }
                return list.ToArray();
            }, fontFolderPath);

            using (var image = Image.Load(inputPath, loadOptions))
            {
                var pdfOptions = new PdfOptions();
                var rasterizationOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };
                pdfOptions.VectorRasterizationOptions = rasterizationOptions;
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
 * 1. When a developer needs to convert CorelDRAW (CDR) files to PDF while preserving brand‑specific fonts stored in a custom directory, they can register the font folder before rendering to ensure correct typography.
 * 2. When an automated document processing pipeline must generate PDF reports from CDR templates that use non‑system fonts, this code loads the custom fonts so the output matches the original design.
 * 3. When a web application allows users to upload CDR artwork and download PDF previews, registering a custom font source guarantees that text appears with the intended typefaces regardless of the server’s installed fonts.
 * 4. When migrating legacy design assets to a cloud‑based storage solution, developers can use this approach to embed custom fonts during CDR‑to‑PDF conversion, avoiding missing‑glyph issues in the final PDFs.
 * 5. When creating batch conversion scripts for marketing materials that rely on corporate fonts located in a shared folder, the code ensures each PDF rendering picks up those fonts automatically.
 */