using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Input\chart.pdf";
            string outputPath = @"C:\Output\chart.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF document
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG rasterization options to preserve size and quality
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    // Preserve text as text for interactivity (axes, labels)
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias
                };

                // Set SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    // Keep text as text (not shapes) to retain data labels
                    TextAsShapes = false
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to embed a PDF‑generated financial chart into a responsive web dashboard and wants the axes and data labels to remain selectable text for tooltips, they can use this Aspose.Imaging C# code to convert the PDF to SVG.
 * 2. When a reporting service exports analytical graphs as PDF but the front‑end requires scalable vector graphics for zoom‑able visualizations, this snippet converts the PDF charts to SVG while preserving vector text for interactive labeling.
 * 3. When an e‑learning platform wants to display exam performance charts from PDF resources on HTML5 pages without losing resolution or searchable text, the code transforms the PDF into SVG with preserved axes and labels.
 * 4. When a GIS application generates map legends as PDF vector charts and needs to render them in a web map viewer with clickable data points, the provided C# routine converts the PDF to SVG while keeping text elements intact.
 * 5. When a marketing automation tool automates the conversion of PDF sales dashboards into web‑friendly SVG assets for SEO‑optimized pages, this Aspose.Imaging example ensures chart axes and data labels stay as editable text.
 */