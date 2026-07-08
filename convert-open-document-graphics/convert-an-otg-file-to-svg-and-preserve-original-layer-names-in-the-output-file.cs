using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageOptions; // For OtgRasterizationOptions and SvgOptions

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.otg";
        string outputPath = @"C:\output\sample.svg";

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

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                var svgOptions = new SvgOptions
                {
                    // Preserve original metadata (including layer names)
                    KeepMetadata = true,
                    // Configure rasterization to match the source size
                    VectorRasterizationOptions = new OtgRasterizationOptions
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
 * 1. When a CAD or GIS application needs to export an OTG (OpenThermalGraphics) map with its original layer names into a scalable SVG for web display.
 * 2. When a printing workflow requires converting multi‑layer OTG design files to SVG while keeping layer metadata for downstream color separation.
 * 3. When a mobile app built with C# must dynamically generate SVG icons from OTG assets, preserving layer names for interactive editing.
 * 4. When a documentation system automates the transformation of engineering diagrams stored as OTG files into searchable SVG files that retain their layer structure.
 * 5. When a batch processing script uses Aspose.Imaging for .NET to migrate legacy OTG artwork to SVG format while ensuring layer names are retained for version control.
 */