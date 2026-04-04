using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        string inputPath = "Input\\sample.cdr";
        string outputPath = "Output\\sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        var loadOptions = new Aspose.Imaging.ImageLoadOptions.CdrLoadOptions();
        loadOptions.AddCustomFontSource(
            (Aspose.Imaging.CustomFontSource)delegate (object[] args)
            {
                string fontsPath = "";
                if (args.Length > 0 && args[0] != null)
                    fontsPath = args[0].ToString();

                var fontList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var file in Directory.GetFiles(fontsPath))
                    {
                        string name = Path.GetFileNameWithoutExtension(file);
                        byte[] data = File.ReadAllBytes(file);
                        fontList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                    }
                }
                return fontList.ToArray();
            },
            "Fonts"
        );

        using (var image = (CdrImage)Image.Load(inputPath, loadOptions))
        {
            using (var pdfOptions = new PdfOptions())
            {
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument,
                    BackgroundColor = Color.White
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}