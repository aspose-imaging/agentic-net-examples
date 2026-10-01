// HOW-TO: Convert PNG to SVG with Embedded Fonts Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.svg";
            string fontsFolder = "fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(fontsFolder);

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] args) =>
            {
                string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                var list = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var fontFile in Directory.GetFiles(fontsPath))
                    {
                        byte[] fontBytes = File.ReadAllBytes(fontFile);
                        string fontName = Path.GetFileNameWithoutExtension(fontFile);
                        list.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                    }
                }
                return list.ToArray();
            }, fontsFolder);

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate scalable SVG graphics from raster PNG assets while preserving custom typography for web or print.
 * 2. When an application must convert user‑uploaded PNG logos into SVG files that include corporate fonts stored in a separate folder.
 * 3. When creating an automated pipeline that transforms product images into vector SVGs with embedded fonts for consistent rendering across browsers.
 * 4. When building a reporting tool that exports charts as PNG and then converts them to SVG with embedded typefaces to ensure text looks identical in PDF exports.
 * 5. When developing a design‑to‑code workflow that requires converting PNG mockups into SVGs with bundled fonts for seamless integration into front‑end projects.
 */
