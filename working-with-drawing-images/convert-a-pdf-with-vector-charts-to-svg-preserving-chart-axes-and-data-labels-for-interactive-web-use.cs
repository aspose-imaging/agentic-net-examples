// HOW-TO: Convert PDF Vector Chart to Interactive SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\chart.pdf";
        string outputPath = @"C:\Data\chart.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF document (vector image)
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                var svgOptions = new SvgOptions
                {
                    // Preserve text as selectable text (not shapes) for interactivity
                    TextAsShapes = false,
                    // No compression to keep the SVG readable
                    Compress = false,
                    // Set rasterization options to match source size
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
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
 * 1. When you need to display PDF‑generated charts on a web page with scalable SVG graphics that keep axis labels and data points selectable.
 * 2. When you want to transform a PDF report containing vector graphs into an SVG file for responsive dashboards without losing text editability.
 * 3. When a reporting tool exports charts as PDF and you must convert them to SVG for client‑side manipulation in JavaScript.
 * 4. When you are building an automated pipeline that extracts vector charts from PDFs and stores them as clean, uncompressed SVG files for archival.
 * 5. When you require a C# solution that loads a PDF, preserves chart text as real text, and saves it as SVG for accessibility compliance.
 */
