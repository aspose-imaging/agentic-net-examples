using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = "/home/user/input.svg";
        string outputPath = "/home/user/output.png";
        string fontFolder = "/home/user/fonts";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure global font settings for Linux
        FontSettings.DefaultFontName = "Arial";
        FontSettings.GetSystemAlternativeFont = false;

        // Prepare LoadOptions with a custom font source delegate
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(
            (object[] args) =>
            {
                string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
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
            },
            fontFolder);

        // Load the vector image with the custom font source
        using (var image = Image.Load(inputPath, loadOptions))
        {
            // Set up vector rasterization options
            var vectorOpts = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            // Prepare PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = vectorOpts
            };

            // Save the rendered image
            image.Save(outputPath, pngOptions);
        }
    }
}