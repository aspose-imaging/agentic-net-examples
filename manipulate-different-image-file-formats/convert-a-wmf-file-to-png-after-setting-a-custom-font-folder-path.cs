// HOW-TO: Convert WMF to PNG with Custom Font Folder in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\sample.wmf";
            string outputPath = "output\\sample.png";
            string fontFolder = "fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new Aspose.Imaging.LoadOptions();
            loadOptions.AddCustomFontSource(GetFontSource, fontFolder);

            using (var image = Aspose.Imaging.Image.Load(inputPath, loadOptions))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                var pngOptions = new PngOptions { VectorRasterizationOptions = vectorOptions };
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
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

/*
 * Real-World Use Cases:
 * 1. When you need to render legacy WMF diagrams that use non‑system fonts into high‑quality PNG images for web display.
 * 2. When a batch conversion tool must process WMF files in a folder while supplying a specific font directory to preserve text appearance.
 * 3. When generating thumbnails of WMF icons in a Windows application that relies on custom corporate fonts.
 * 4. When converting WMF reports to PNG for inclusion in PDF documents, ensuring the correct fonts are embedded from a custom folder.
 * 5. When automating document workflows that require converting vector WMF graphics to raster PNGs on a server without installing the fonts system‑wide.
 */
