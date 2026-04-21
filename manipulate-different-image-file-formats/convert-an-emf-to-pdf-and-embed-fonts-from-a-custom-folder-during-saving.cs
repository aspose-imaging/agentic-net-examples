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
            string inputPath = "C:\\input.emf";
            string outputPath = "C:\\output.pdf";
            string fontFolder = "C:\\fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(GetFontSource, fontFolder);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
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
        if (args.Length > 0)
        {
            fontsPath = args[0]?.ToString();
        }

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