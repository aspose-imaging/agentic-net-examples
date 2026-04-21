using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.wmf";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Prepare SVG save options (keep text as text for replacement)
            SvgOptions saveOptions = new SvgOptions
            {
                TextAsShapes = false // keep text as text nodes
            };

            // Configure rasterization options
            WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Color.WhiteSmoke,
                PageSize = wmfImage.Size,
                RenderMode = WmfRenderMode.Auto
            };
            saveOptions.VectorRasterizationOptions = rasterOptions;

            // Save to a memory stream to obtain SVG content as string
            string svgContent;
            using (MemoryStream ms = new MemoryStream())
            {
                wmfImage.Save(ms, saveOptions);
                svgContent = Encoding.UTF8.GetString(ms.ToArray());
            }

            // Simple localization dictionary (replace original text with translations)
            var translations = new Dictionary<string, string>
            {
                { "Hello", "Bonjour" },
                { "World", "Monde" }
                // Add more key/value pairs as needed
            };

            // Perform text replacements
            foreach (var kvp in translations)
            {
                svgContent = svgContent.Replace(kvp.Key, kvp.Value);
            }

            // Write the localized SVG to the output file
            File.WriteAllText(outputPath, svgContent, Encoding.UTF8);
        }
    }
}