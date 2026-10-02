// HOW-TO: How To Substitute Missing Fonts When Saving SVG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.svg";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] fontArgs) =>
            {
                string fontsPath = fontArgs.Length > 0 ? fontArgs[0]?.ToString() : string.Empty;
                var fontList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var fontFile in Directory.GetFiles(fontsPath))
                    {
                        byte[] fontBytes = File.ReadAllBytes(fontFile);
                        string fontName = Path.GetFileNameWithoutExtension(fontFile);
                        fontList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                    }
                }
                return fontList.ToArray();
            }, "fonts");

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                image.Save(outputPath);
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
 * 1. When an SVG file references fonts that are not installed on the server, a developer can load the SVG with a custom font source and save it so the text renders correctly.
 * 2. When generating SVG reports from a web application that uses corporate brand fonts, the code ensures the output SVG includes those fonts even if they are missing on the client machine.
 * 3. When batch‑processing a folder of SVG assets for a mobile app, the developer can provide a directory of font files to replace missing fonts before saving the images.
 * 4. When converting user‑uploaded SVG graphics to another format later, configuring font substitution prevents loss of text appearance during the initial load.
 * 5. When automating SVG rendering in a CI/CD pipeline, the script guarantees consistent typography by loading custom fonts from a specified path before saving the SVG.
 */
