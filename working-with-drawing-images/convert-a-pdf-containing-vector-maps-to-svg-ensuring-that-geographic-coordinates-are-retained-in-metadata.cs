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
        string inputPath = @"C:\Input\map.pdf";
        string outputPath = @"C:\Output\map.svg";

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

            // Load the PDF (vector) image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                var svgOptions = new SvgOptions
                {
                    // Preserve original metadata (including geographic coordinates)
                    KeepMetadata = true
                };

                // Configure vector rasterization options (page size matches source)
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a GIS developer needs to convert a PDF containing vector map data into an SVG for web display while preserving the geographic coordinate metadata for later spatial analysis.
 * 2. When a cartographer wants to automate the batch conversion of vector‑based PDF atlases to scalable SVG files so that the maps can be styled with CSS without losing the embedded coordinate reference system.
 * 3. When a mobile app team requires lightweight vector graphics extracted from PDF floor plans and needs to keep the original metadata intact for indoor navigation calculations.
 * 4. When an e‑learning platform must transform PDF engineering diagrams into interactive SVGs that retain measurement metadata for dynamic scaling in HTML5 lessons.
 * 5. When a data‑visualization engineer needs to programmatically export vector map PDFs to SVG format using C# and Aspose.Imaging while ensuring the coordinate metadata is retained for integration with mapping libraries.
 */