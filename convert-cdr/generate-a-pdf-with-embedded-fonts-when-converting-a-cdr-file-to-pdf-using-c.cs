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
            loadOptions.AddCustomFontSource(GetFontSource, fontFolderPath);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var pdfOptions = new PdfOptions();

                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static Aspose.Imaging.CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
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
 * 1. When a graphic design studio needs to automate the batch conversion of CorelDRAW (.cdr) artwork into print‑ready PDF files with all custom fonts embedded to guarantee consistent typography across devices.
 * 2. When an e‑learning platform must generate PDF handouts from CDR lesson diagrams on the fly, ensuring the embedded fonts preserve the original layout without requiring the end‑user to install the fonts.
 * 3. When a document management system integrates Aspose.Imaging to convert vendor‑supplied CDR marketing assets into searchable PDFs while embedding the corporate typefaces stored in a dedicated Fonts folder.
 * 4. When a cloud‑based printing service processes customer‑uploaded CDR files and needs to embed the selected fonts in the resulting PDF to meet PDF/X‑1a compliance for commercial printing.
 * 5. When a software developer builds a C# utility that extracts vector graphics from CorelDRAW files and saves them as PDFs with embedded fonts to maintain visual fidelity for archival and legal documentation.
 */