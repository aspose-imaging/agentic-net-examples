// HOW-TO: Convert WMF to SVG Preserving Text and Fonts in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.wmf";
        string outputPath = @"C:\temp\output.svg";

        try
        {
            // Verify that the input WMF file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Configure SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    // Preserve text as text (do not convert to shapes)
                    TextAsShapes = false
                };

                // Configure rasterization options for WMF
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    // Optional: set background color
                    BackgroundColor = Color.WhiteSmoke,
                    // Use the original image size as page size
                    PageSize = wmfImage.Size,
                    // Render embedded EMF if present, otherwise WMF
                    RenderMode = WmfRenderMode.Auto
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as SVG
                wmfImage.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to migrate legacy WMF diagrams to scalable SVG files for web pages while keeping the original text searchable and the embedded fonts intact.
 * 2. When generating high‑resolution printable graphics from WMF drawings and wants the SVG output to retain exact text layout without converting characters to vector shapes.
 * 3. When building a responsive UI that requires WMF icons to be displayed as SVG so they scale smoothly, and the code must preserve the original font styling.
 * 4. When creating accessible documentation that includes WMF charts, and the SVG conversion must keep the text as selectable text for screen readers and indexing.
 * 5. When automating a batch process that converts a library of WMF assets to SVG for a design system, ensuring that any embedded EMF or font information is retained during conversion.
 */
