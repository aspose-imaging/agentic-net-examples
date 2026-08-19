// HOW-TO: Convert CDR to PDF with Embedded Fonts Using C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(
                (object[] args) =>
                {
                    string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                    var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (Directory.Exists(fontsPath))
                    {
                        foreach (var file in Directory.GetFiles(fontsPath))
                        {
                            string name = Path.GetFileNameWithoutExtension(file);
                            byte[] data = File.ReadAllBytes(file);
                            fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                        }
                    }
                    return fonts.ToArray();
                },
                "Fonts"
            );

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
}

/*
 * Real-World Use Cases:
 * 1. When a design studio needs to deliver CorelDRAW artwork as PDF files that preserve the original typography on any device, they can use this code to embed the fonts during conversion.
 * 2. When an automated document pipeline processes batch CDR files and must generate searchable PDFs that retain the exact font appearance, the example shows how to load custom fonts and embed them.
 * 3. When a web application allows users to upload CDR drawings and preview them as PDFs without missing characters, developers can apply this approach to ensure all fonts are included.
 * 4. When a printing service converts client‑supplied CDR files to PDF for high‑resolution printing and wants to avoid font substitution issues, this code embeds the required fonts automatically.
 * 5. When a compliance system archives graphic assets in PDF format and requires the PDFs to be self‑contained with embedded fonts for legal preservation, the snippet provides the necessary steps in C#.
 */
