using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.wmf";
            string outputPath = "Output\\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WMF image with custom fonts
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(
                (object[] fontArgs) =>
                {
                    string fontsPath = fontArgs.Length > 0 ? fontArgs[0]?.ToString() : string.Empty;
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
                },
                "Fonts"
            );

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
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}