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
        string inputPath = @"C:\Temp\sample.odg";
        string outputPath = @"C:\Temp\sample.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                SvgOptions svgOptions = new SvgOptions
                {
                    // Preserve original metadata (including layer information if present)
                    KeepMetadata = true,

                    // Configure vector rasterization (page size, background, etc.)
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
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
 * 1. When a developer needs to convert OpenDocument Graphics (ODG) files to Scalable Vector Graphics (SVG) for web display while keeping the original layer names intact using Aspose.Imaging for .NET in a C# application.
 * 2. When an engineering team wants to automate the migration of legacy ODG drawings into SVG format for inclusion in responsive HTML5 dashboards, ensuring that each drawing’s layers remain identifiable.
 * 3. When a document management system must ingest ODG assets and store them as SVG files with preserved metadata so that downstream tools can reference the original layer structure.
 * 4. When a desktop publishing workflow requires batch processing of ODG illustrations into SVG for high‑resolution printing, and the code must retain layer names for later editing in vector editors.
 * 5. When a GIS or CAD integration project needs to programmatically read ODG map layers and export them as SVG while preserving layer information for accurate rendering in mapping applications.
 */