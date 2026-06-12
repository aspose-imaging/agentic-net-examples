using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        string inputPath = "Input\\sample.cdr";
        string outputPath = "Output\\sample.pdf";
        string fontsPath = "Fonts";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((args) =>
            {
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (args.Length > 0 && args[0] != null)
                {
                    string dir = args[0].ToString();
                    if (Directory.Exists(dir))
                    {
                        foreach (var file in Directory.GetFiles(dir))
                        {
                            string name = Path.GetFileNameWithoutExtension(file);
                            byte[] data = File.ReadAllBytes(file);
                            fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                        }
                    }
                }
                return fonts.ToArray();
            }, fontsPath);

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
 * 1. When a graphic design studio needs to convert CorelDRAW (.cdr) files with custom brand fonts into PDF for client review while guaranteeing that the PDFs display the exact typography on any device.
 * 2. When an automated document generation system must batch‑process CDR artwork into PDF brochures and embed the used fonts to avoid missing‑font warnings in downstream print workflows.
 * 3. When a web application offers users the ability to upload CDR logos and download PDF versions that retain the original font styling without requiring the end‑user to have those fonts installed.
 * 4. When a legal compliance tool archives engineering diagrams from CDR format as PDFs and must embed the embedded fonts to ensure the archived files are self‑contained and future‑proof.
 * 5. When a cloud‑based printing service converts customer‑provided CDR files to PDF and needs to embed the custom fonts so that the printed output matches the on‑screen design exactly.
 */