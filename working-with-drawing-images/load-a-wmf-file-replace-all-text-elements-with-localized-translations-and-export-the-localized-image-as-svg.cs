// HOW-TO: Localize WMF Text and Export as SVG Using C# Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\source.wmf";
            string outputPath = @"C:\Images\localized_output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define simple localization dictionary (key = original text, value = translated text)
            var translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Hello", "Hola" },
                { "World", "Mundo" },
                // Add more translations as needed
            };

            // Load WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options with text preserved (not converted to shapes)
                var svgOptions = new SvgOptions
                {
                    TextAsShapes = false // keep <text> elements for replacement
                };

                // Configure rasterization options (required for vector formats)
                var rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = wmfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save to a memory stream first
                using (var ms = new MemoryStream())
                {
                    wmfImage.Save(ms, svgOptions);
                    ms.Position = 0;
                    string svgContent = new StreamReader(ms).ReadToEnd();

                    // Replace text based on the translation dictionary
                    foreach (var kvp in translations)
                    {
                        // Simple string replace; for more complex scenarios consider XML parsing
                        svgContent = svgContent.Replace(kvp.Key, kvp.Value);
                    }

                    // Write the localized SVG to the output file
                    File.WriteAllText(outputPath, svgContent);
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
 * 1. When you need to create multilingual versions of legacy WMF diagrams for web display by replacing embedded text and saving them as scalable SVG files.
 * 2. When an application must programmatically translate labels in vector icons stored in WMF format without rasterizing them, preserving editability in the output SVG.
 * 3. When a batch process has to read WMF assets, apply a custom dictionary of translations, and generate localized SVG assets for responsive UI themes.
 * 4. When you want to integrate Aspose.Imaging into a C# localization pipeline to replace specific words in technical schematics and export them as clean SVG markup.
 * 5. When a developer must ensure that text elements remain as <text> nodes (not shapes) during conversion so they can be indexed or styled after localization.
 */
