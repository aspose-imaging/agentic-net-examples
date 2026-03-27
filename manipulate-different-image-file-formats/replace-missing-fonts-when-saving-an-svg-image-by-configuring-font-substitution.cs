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
        loadOptions.AddCustomFontSource((object[] parameters) =>
        {
            string fontsPath = string.Empty;
            if (parameters != null && parameters.Length > 0 && parameters[0] != null)
                fontsPath = parameters[0].ToString();

            var fontDataList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
            if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
            {
                foreach (var file in Directory.GetFiles(fontsPath))
                {
                    string fontName = Path.GetFileNameWithoutExtension(file);
                    byte[] fontBytes = File.ReadAllBytes(file);
                    fontDataList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                }
            }
            return fontDataList.ToArray();
        }, fontFolderPath);

        using (Image image = Image.Load(inputPath, loadOptions))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height
            };

            var saveOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorOptions,
                TextAsShapes = false
            };

            image.Save(outputPath, saveOptions);
        }
    }
}