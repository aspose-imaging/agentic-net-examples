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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.svg";
        string fontFolder = @"C:\Fonts";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Prepare load options with custom font source
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(
            args =>
            {
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                foreach (var file in Directory.GetFiles(fontFolder))
                {
                    string fontName = Path.GetFileNameWithoutExtension(file);
                    byte[] fontData = File.ReadAllBytes(file);
                    fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontData));
                }
                return fonts.ToArray();
            },
            fontFolder
        );

        // Load the SVG image with custom fonts
        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Configure SVG save options (keep fonts as references)
            var saveOptions = new SvgOptions
            {
                TextAsShapes = false // preserve text so fonts can be referenced or embedded
            };

            // Save the SVG file
            image.Save(outputPath, saveOptions);
        }
    }
}