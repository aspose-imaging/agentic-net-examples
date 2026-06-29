using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.pdf";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Read original SVG content
            string svgContent = File.ReadAllText(inputPath);

            // Apply a custom dash pattern to every <path> element
            // This simple replacement adds a stroke-dasharray attribute if not present
            // and forces a stroke color and width.
            string modifiedSvg = System.Text.RegularExpressions.Regex.Replace(
                svgContent,
                @"<path([^>]*?)>",
                m =>
                {
                    string attrs = m.Groups[1].Value;
                    // Ensure stroke, stroke-width and dash pattern are set
                    if (!attrs.Contains("stroke="))
                        attrs += " stroke=\"black\"";
                    if (!attrs.Contains("stroke-width="))
                        attrs += " stroke-width=\"2\"";
                    if (!attrs.Contains("stroke-dasharray="))
                        attrs += " stroke-dasharray=\"5,5\"";
                    return $"<path{attrs}>";
                },
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // Write the modified SVG to a temporary file
            string tempSvgPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_modified.svg");
            File.WriteAllText(tempSvgPath, modifiedSvg);

            // Load the modified SVG using Aspose.Imaging
            using (Image image = Image.Load(tempSvgPath))
            {
                // Prepare PDF export options with vector rasterization
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }

            // Clean up temporary file
            if (File.Exists(tempSvgPath))
                File.Delete(tempSvgPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate printable PDFs from vector graphics and wants to emphasize outlines by adding a dashed stroke to every path in an SVG using C# and Aspose.Imaging.
 * 2. When an engineering team automates the creation of technical diagrams where consistent line styling (e.g., black 2‑pixel dashed lines) must be applied to all SVG paths before exporting to PDF for documentation.
 * 3. When a web application converts user‑uploaded SVG icons into PDF assets and requires a uniform stroke pattern to meet brand guidelines without manually editing each file.
 * 4. When a batch‑processing script processes a folder of SVG floor plans, injects a custom stroke‑dasharray attribute into each path, and saves the styled drawings as PDF reports using Aspose.Imaging for .NET.
 * 5. When a developer integrates SVG to PDF conversion into a CI/CD pipeline and needs to programmatically enforce stroke width, color, and dash pattern on all vector paths to ensure visual consistency across generated PDFs.
 */