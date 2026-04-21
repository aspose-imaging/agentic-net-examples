using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.svg";
        string fontFolderPath = @"C:\Fonts";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource((obj) =>
        {
            string fontsPath = obj.Length > 0 ? obj[0]?.ToString() : string.Empty;
            var customFonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();

            if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
            {
                foreach (var fontFile in Directory.GetFiles(fontsPath))
                {
                    byte[] fontData = File.ReadAllBytes(fontFile);
                    string fontName = Path.GetFileNameWithoutExtension(fontFile);
                    customFonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontData));
                }
            }

            return customFonts.ToArray();
        }, fontFolderPath);

        using (Image image = Image.Load(inputPath, loadOptions))
        {
            var rasterOptions = new SvgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height
            };

            var svgSaveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                TextAsShapes = false
            };

            image.Save(outputPath, svgSaveOptions);
        }
    }
}