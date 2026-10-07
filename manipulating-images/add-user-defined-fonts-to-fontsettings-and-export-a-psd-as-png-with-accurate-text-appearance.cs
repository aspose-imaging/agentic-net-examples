// HOW-TO: Export PSD to PNG with Custom Fonts Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/sample.png";
            string fontFolderPath = "Fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] args) =>
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

            using (var image = Image.Load(inputPath, loadOptions))
            {
                using (var pngOptions = new PngOptions())
                {
                    pngOptions.Source = new FileCreateSource(outputPath, false);
                    image.Save(outputPath, pngOptions);
                }
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
 * 1. When you need to convert a Photoshop PSD file to a PNG while ensuring that any missing fonts are supplied from a local folder so the text renders correctly.
 * 2. When an automated image‑processing pipeline must generate web‑ready PNG previews of PSD designs that rely on custom corporate fonts not installed on the server.
 * 3. When you are building a C# desktop application that loads user‑provided PSD files and saves them as PNGs, and you must embed private fonts to preserve branding.
 * 4. When a cloud service processes batch PSD assets and must avoid font‑fallback issues by loading fonts from a specified directory before exporting to PNG.
 * 5. When you want to programmatically render layered PSD artwork with accurate typography in a .NET environment without manually installing each font on the machine.
 */
