// HOW-TO: Convert SVG to PDF with Embedded Fonts Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.pdf";
        string fontFolderPath = "Fonts";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(args =>
            {
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (args.Length > 0)
                {
                    string fontsPath = args[0]?.ToString() ?? string.Empty;
                    if (Directory.Exists(fontsPath))
                    {
                        foreach (var file in Directory.GetFiles(fontsPath))
                        {
                            string name = Path.GetFileNameWithoutExtension(file);
                            byte[] data = File.ReadAllBytes(file);
                            fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                        }
                    }
                }
                return fonts.ToArray();
            }, fontFolderPath);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var pdfOptions = new PdfOptions();

                var vectorOpts = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };
                pdfOptions.VectorRasterizationOptions = vectorOpts;

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
 * 1. When you need to generate PDF reports from SVG graphics and must ensure that any custom text fonts appear correctly on any viewer.
 * 2. When an application processes user‑uploaded SVG files that reference external fonts and you want the resulting PDF to be self‑contained without missing glyphs.
 * 3. When automating batch conversion of design assets to PDF and the fonts are stored in a separate directory that must be embedded during conversion.
 * 4. When creating printable PDFs from web‑based SVG diagrams where the target audience may not have the original font files installed.
 * 5. When integrating Aspose.Imaging into a C# service that converts SVG logos to PDF and must embed the corporate brand fonts for compliance.
 */
