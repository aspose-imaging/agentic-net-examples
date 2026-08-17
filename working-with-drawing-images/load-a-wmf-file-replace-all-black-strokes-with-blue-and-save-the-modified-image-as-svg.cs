// HOW-TO: Convert WMF to SVG and Change Black Strokes to Blue in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.svg";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options
                var svgOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                var rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                    PageSize = wmfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save to a memory stream first
                using (var ms = new MemoryStream())
                {
                    wmfImage.Save(ms, svgOptions);
                    ms.Position = 0;

                    // Read SVG content as text
                    string svgContent = new StreamReader(ms).ReadToEnd();

                    // Replace black strokes with blue
                    svgContent = svgContent
                        .Replace("#000000", "#0000FF")
                        .Replace("stroke:black", "stroke:blue")
                        .Replace("stroke:#000", "stroke:#00F");

                    // Write the modified SVG to the output file
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
 * 1. When you need to modernize legacy WMF diagrams for web display by converting them to scalable SVG files while recoloring black lines to match a brand’s blue palette.
 * 2. When generating printable vector assets from old Windows Metafile icons and you must replace default black outlines with a custom color to integrate with a UI theme.
 * 3. When automating batch processing of engineering schematics stored as WMF and you want to output SVG versions with blue strokes for better visibility on dark backgrounds.
 * 4. When creating an SVG export feature in a C# application that loads WMF graphics, changes their stroke color, and saves them for use in responsive web pages.
 * 5. When integrating Aspose.Imaging into a workflow that converts legacy vector files to SVG and needs to programmatically adjust stroke colors without manual editing.
 */
