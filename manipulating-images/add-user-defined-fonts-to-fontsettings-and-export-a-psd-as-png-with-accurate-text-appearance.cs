using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
        string outputPath = "output.png";
        string fontsFolder = "fonts";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(
            (object[] _) =>
            {
                var list = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (Directory.Exists(fontsFolder))
                {
                    foreach (var file in Directory.GetFiles(fontsFolder))
                    {
                        var data = File.ReadAllBytes(file);
                        var name = Path.GetFileNameWithoutExtension(file);
                        list.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                    }
                }
                return list.ToArray();
            }, fontsFolder);

        using (Image psdImage = Image.Load(inputPath, loadOptions))
        {
            var vectorOpts = new VectorRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                BackgroundColor = Color.White,
                PageWidth = psdImage.Width,
                PageHeight = psdImage.Height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = vectorOpts
            };

            psdImage.Save(outputPath, pngOptions);
        }
    }
}