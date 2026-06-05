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
            string inputPath = "input.emf";
            string outputPath = "output.pdf";
            string fontFolder = "fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] fontArgs) =>
            {
                string fontsPath = fontArgs.Length > 0 ? fontArgs[0]?.ToString() : string.Empty;
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var file in Directory.GetFiles(fontsPath))
                    {
                        string name = Path.GetFileNameWithoutExtension(file);
                        byte[] data = File.ReadAllBytes(file);
                        fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                    }
                }
                return fonts.ToArray();
            }, fontFolder);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

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
 * 1. When a Windows desktop application must generate printable PDF reports from vector‑based EMF charts while ensuring corporate brand fonts stored in a dedicated “fonts” directory are embedded for consistent rendering on any device.
 * 2. When an automated document conversion service processes legacy EMF diagrams and needs to embed custom TrueType fonts from a shared network folder to comply with PDF/A archival standards.
 * 3. When a batch‑processing script converts engineering schematics saved as EMF files to PDF for client delivery, pulling required specialty fonts from a project‑specific folder to avoid missing‑glyph issues.
 * 4. When a web API receives user‑uploaded EMF logos and returns PDF thumbnails that preserve the original typography by loading font files from a configurable custom font path.
 * 5. When a CI/CD pipeline validates that UI mockups exported as EMF are correctly rendered as PDFs with all custom UI fonts embedded, using the code to load fonts from a repository‑managed fonts folder.
 */