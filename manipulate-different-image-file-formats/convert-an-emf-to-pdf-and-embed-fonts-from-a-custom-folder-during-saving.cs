// HOW-TO: Convert EMF to PDF with Custom Font Embedding in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.emf");
            string outputPath = Path.Combine("Output", "sample.pdf");
            string fontsFolder = "Fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] args) =>
            {
                string path = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                var list = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                {
                    foreach (var fontFile in Directory.GetFiles(path))
                    {
                        byte[] fontBytes = File.ReadAllBytes(fontFile);
                        string fontName = Path.GetFileNameWithoutExtension(fontFile);
                        list.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                    }
                }
                return list.ToArray();
            }, fontsFolder);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
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
 * 1. When you need to generate a PDF report from vector EMF graphics while ensuring the document uses company‑specific fonts stored in a separate folder.
 * 2. When an application must convert user‑uploaded EMF logos to PDF for printing, embedding the required fonts to avoid missing‑font warnings on any printer.
 * 3. When automating batch processing of EMF diagrams into PDF files and the fonts are not installed on the server, so they must be supplied from a custom directory.
 * 4. When creating PDF invoices that contain EMF‑based watermarks and you want the watermark text to appear with the exact font style regardless of the viewer’s system fonts.
 * 5. When integrating Aspose.Imaging into a C# service that converts EMF drawings to PDF and you need to guarantee that all text renders correctly by loading fonts from a configurable fonts folder.
 */
