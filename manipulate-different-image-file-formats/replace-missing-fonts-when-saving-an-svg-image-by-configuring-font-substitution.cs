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
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.svg";
            string fontFolderPath = @"C:\Fonts";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] fArgs) =>
            {
                string fontsPath = fArgs.Length > 0 ? fArgs[0]?.ToString() : string.Empty;
                var customFontData = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var fontFile in Directory.GetFiles(fontsPath))
                    {
                        customFontData.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(
                            Path.GetFileNameWithoutExtension(fontFile),
                            File.ReadAllBytes(fontFile)));
                    }
                }
                return customFontData.ToArray();
            }, fontFolderPath);

            using (var image = Image.Load(inputPath, loadOptions))
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
 * 1. When a web application generates SVG reports that reference corporate fonts not installed on the server, a developer can use this code to load the SVG with a custom font folder and ensure the saved file retains the correct typography.
 * 2. When migrating legacy design assets to a new CI/CD pipeline, developers can employ this approach to substitute missing TrueType or OpenType fonts during SVG processing so the output images render consistently across environments.
 * 3. When building a batch conversion tool that converts user‑uploaded SVG icons to optimized SVG files on Windows, the code allows the tool to supply a local font directory to replace any unavailable fonts and avoid rendering errors.
 * 4. When creating an automated documentation generator that embeds SVG diagrams with custom brand fonts, developers can configure font substitution via LoadOptions to guarantee the final SVG files display the brand’s typeface even on machines lacking those fonts.
 * 5. When integrating Aspose.Imaging into a cloud‑based image service that receives SVG payloads from various clients, this snippet lets the service load the SVG with a predefined font repository, ensuring missing fonts are replaced before the image is saved and returned.
 */