using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "/path/to/input";
        string outputPath = "/path/to/output";
        string fontFolderPath = "/path/to/fonts";
        string fileName = "sample.emf";

        FontSettings.DefaultFontName = "Arial";
        FontSettings.SetFontsFolder(fontFolderPath);

        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(
            (object[] args) =>
            {
                string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                var customFonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var fontFile in Directory.GetFiles(fontsPath))
                    {
                        customFonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(
                            Path.GetFileNameWithoutExtension(fontFile),
                            File.ReadAllBytes(fontFile)));
                    }
                }
                return customFonts.ToArray();
            },
            fontFolderPath);

        using (var image = Image.Load(Path.Combine(inputPath, fileName), loadOptions))
        {
            var vectorOpts = new VectorRasterizationOptions
            {
                PageWidth = image.Width,
                PageHeight = image.Height,
                BackgroundColor = Color.White,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            var pngOptions = new PngOptions { VectorRasterizationOptions = vectorOpts };
            string outputFile = Path.Combine(outputPath, Path.GetFileNameWithoutExtension(fileName) + ".png");
            image.Save(outputFile, pngOptions);
        }
    }
}