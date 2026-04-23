using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            Directory.CreateDirectory(outputDir);

            string[] cdrFiles = Directory.GetFiles(inputDir, "*.cdr");

            foreach (var inputPath in cdrFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new Aspose.Imaging.ImageLoadOptions.CdrLoadOptions();
                loadOptions.AddCustomFontSource((args) =>
                {
                    var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (args.Length > 0 && args[0] != null)
                    {
                        string fontsPath = args[0].ToString();
                        if (Directory.Exists(fontsPath))
                        {
                            foreach (var fontFile in Directory.GetFiles(fontsPath))
                            {
                                string fontName = Path.GetFileNameWithoutExtension(fontFile);
                                byte[] fontData = File.ReadAllBytes(fontFile);
                                fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontData));
                            }
                        }
                    }
                    return fonts.ToArray();
                }, "Fonts");

                using (var image = (CdrImage)Image.Load(inputPath, loadOptions))
                {
                    using (var pdfOptions = new PdfOptions())
                    {
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
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}