using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.emf";
        string outputPath = "Output\\sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        var loadOptions = new LoadOptions();
        string fontsFolder = "Fonts";
        loadOptions.AddCustomFontSource(fontArgs =>
        {
            string path = fontArgs.Length > 0 ? fontArgs[0]?.ToString() : string.Empty;
            var list = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
            if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path))
                {
                    byte[] data = File.ReadAllBytes(file);
                    string name = Path.GetFileNameWithoutExtension(file);
                    list.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                }
            }
            return list.ToArray();
        }, fontsFolder);

        using (Image image = Image.Load(inputPath, loadOptions))
        {
            using (var pdfOptions = new PdfOptions())
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
}