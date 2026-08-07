using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Input\chart.pdf";
            string outputPath = @"C:\Output\chart.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF (vector image) using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options
                var svgOptions = new SvgOptions
                {
                    // Keep text as text (axes labels, data labels) for interactivity
                    TextAsShapes = false
                };

                // Set rasterization options – page size matches the source image size
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as SVG
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
 * 1. When a developer needs to embed a PDF‑generated financial chart into a responsive web dashboard and wants the axes and data labels to remain searchable and interactive, they can use this code to convert the PDF to SVG.
 * 2. When an e‑learning platform requires high‑resolution scientific graphs from PDF lecture notes to be displayed as scalable vector graphics on HTML5 pages, this snippet enables conversion while preserving chart text.
 * 3. When a reporting tool must export quarterly KPI charts from PDF reports to SVG for client‑side manipulation (e.g., tooltip overlays) without losing vector quality, the code provides the needed transformation.
 * 4. When a marketing website wants to showcase product performance diagrams originally created in PDF and needs them as lightweight, searchable SVG files for SEO and accessibility, this example performs the conversion.
 * 5. When a developer is building a data‑visualization library that consumes PDF chart assets and needs to render them as interactive SVG elements with intact axis labels in a C# .NET application, this code handles the conversion process.
 */