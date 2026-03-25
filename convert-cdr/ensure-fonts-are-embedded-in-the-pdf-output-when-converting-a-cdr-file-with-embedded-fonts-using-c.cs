using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.cdr");
        string outputPath = Path.Combine("Output", "sample.pdf");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        string fontsFolder = Path.Combine("Fonts");

        var cdrLoadOptions = new Aspose.Imaging.ImageLoadOptions.CdrLoadOptions();
        cdrLoadOptions.AddCustomFontSource((object[] args) =>
        {
            string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
            var list = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
            if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
            {
                foreach (var fontFile in Directory.GetFiles(fontsPath))
                {
                    byte[] fontBytes = File.ReadAllBytes(fontFile);
                    string fontName = Path.GetFileNameWithoutExtension(fontFile);
                    list.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                }
            }
            return list.ToArray();
        }, fontsFolder);

        using (Image image = Image.Load(inputPath, cdrLoadOptions))
        {
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                var rasterOptions = new CdrRasterizationOptions();
                rasterOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
                rasterOptions.SmoothingMode = SmoothingMode.None;
                rasterOptions.Positioning = PositioningTypes.DefinedByDocument;

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, pdfOptions);
            }
        }
    }
}