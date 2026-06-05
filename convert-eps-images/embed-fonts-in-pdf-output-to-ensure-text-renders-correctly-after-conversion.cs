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
            string inputPath = "Input/sample.svg";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(GetFontSource, "Fonts");

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
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

    private static Aspose.Imaging.CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = string.Empty;
        if (args.Length > 0 && args[0] != null)
        {
            fontsPath = args[0].ToString();
        }

        var fontDataList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
        if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
        {
            foreach (var fontFile in Directory.GetFiles(fontsPath))
            {
                string fontName = Path.GetFileNameWithoutExtension(fontFile);
                byte[] fontBytes = File.ReadAllBytes(fontFile);
                fontDataList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
            }
        }

        return fontDataList.ToArray();
    }
}