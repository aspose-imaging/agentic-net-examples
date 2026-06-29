using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\temp\input.wmf";
            string outputPath = @"C:\temp\output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = false
                };
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert legacy Windows Metafile (WMF) diagrams into scalable SVG files while preserving editable text for later localization using Aspose.Imaging in a C# application.
 * 2. When a software product requires generating multilingual UI icons by loading WMF assets, swapping the embedded text with translated strings, and exporting them as SVG for responsive web interfaces.
 * 3. When an engineering documentation workflow must transform WMF schematics into SVG format so that the text remains selectable and can be indexed by search engines after translation.
 * 4. When an automated build script has to batch‑process WMF assets, replace their text nodes with locale‑specific content, and save the results as SVG to support accessibility standards.
 * 5. When a developer is building a .NET service that ingests WMF files, applies localized captions, and delivers SVG output for integration with modern HTML5 canvas or SVG editors.
 */