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

            // Load the PDF document (vector image)
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization to preserve vector data
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size // keep original size
                };

                // Set SVG save options; keep text as text for interactivity
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions,
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
 * 1. When a developer needs to embed a PDF‑generated chart into a responsive web page and wants the axes and data labels to remain selectable and interactive, they can convert the PDF to SVG using this code.
 * 2. When an analytics dashboard must display vector‑based financial graphs from PDF reports without losing resolution, the code enables conversion to scalable SVG while preserving text elements.
 * 3. When a content management system imports client‑provided PDF charts and must serve them as lightweight, searchable SVG files for SEO and accessibility, this snippet performs the transformation.
 * 4. When an e‑learning platform requires high‑quality, zoomable diagrams from PDF lecture notes and wants to keep the chart labels editable in the browser, the code converts the PDF to SVG with text retained.
 * 5. When a mobile app needs to render PDF chart assets offline as vector graphics to reduce memory usage and maintain crisp axes on different screen sizes, this C# example rasterizes the PDF to SVG while preserving vector data.
 */