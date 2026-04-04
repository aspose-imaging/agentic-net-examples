using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Prepare LoadOptions with a custom font source that provides Arial
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(
            (object[] fontArgs) =>
            {
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                string fontsFolder = fontArgs.Length > 0 ? fontArgs[0]?.ToString() : string.Empty;
                string arialPath = Path.Combine(fontsFolder, "arial.ttf");
                if (File.Exists(arialPath))
                {
                    byte[] fontData = File.ReadAllBytes(arialPath);
                    fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData("Arial", fontData));
                }
                return fonts.ToArray();
            },
            @"C:\Windows\Fonts"
        );

        // Load the EMF image with custom font handling
        using (var emfImage = (Aspose.Imaging.FileFormats.Emf.EmfImage)Image.Load(inputPath, loadOptions))
        {
            // Set up SVG save options
            var saveOptions = new SvgOptions
            {
                // Keep text as text (default) so the new font is applied
                TextAsShapes = false
            };

            // Configure rasterization options for EMF to SVG conversion
            var rasterOptions = new EmfRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                PageSize = emfImage.Size,
                RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                BorderX = 0,
                BorderY = 0
            };

            saveOptions.VectorRasterizationOptions = rasterOptions;

            // Save as SVG
            emfImage.Save(outputPath, saveOptions);
        }
    }
}