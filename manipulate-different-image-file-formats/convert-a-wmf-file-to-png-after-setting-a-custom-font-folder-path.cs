using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Input\sample.wmf";
        string outputPath = @"C:\Output\sample.png";
        string fontFolderPath = @"C:\Fonts";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(GetFontSource, fontFolderPath);

        using (Image image = Image.Load(inputPath, loadOptions))
        {
            var rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            image.Save(outputPath, pngOptions);
        }
    }

    static Aspose.Imaging.CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
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