using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
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

            // Load WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options (keep text as text for later replacement)
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = false // keep text elements as text nodes
                };

                // Configure rasterization options
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                    PageSize = wmfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save WMF as SVG (temporary file)
                wmfImage.Save(outputPath, saveOptions);
            }

            // Simple translation dictionary (original text -> localized text)
            Dictionary<string, string> translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Hello", "Hola" },
                { "World", "Mundo" }
                // Add more translations as needed
            };

            // Read the generated SVG content
            string svgContent = File.ReadAllText(outputPath);

            // Replace text elements based on the translation dictionary
            foreach (var kvp in translations)
            {
                // Replace occurrences of the original text with the localized version
                svgContent = svgContent.Replace(kvp.Key, kvp.Value);
            }

            // Write the localized SVG back to the output file
            File.WriteAllText(outputPath, svgContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}