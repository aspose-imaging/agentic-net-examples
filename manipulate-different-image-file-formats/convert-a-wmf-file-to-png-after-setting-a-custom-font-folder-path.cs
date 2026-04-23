using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input, output and font folder paths
            string inputPath = @"C:\input\sample.wmf";
            string outputPath = @"C:\output\sample.png";
            string fontFolderPath = @"C:\fonts";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up custom font source using a lambda
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((args) =>
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
            }, fontFolderPath);

            // Load WMF image with custom fonts
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Set up vector rasterization options for proper rendering
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                // Configure PNG save options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}