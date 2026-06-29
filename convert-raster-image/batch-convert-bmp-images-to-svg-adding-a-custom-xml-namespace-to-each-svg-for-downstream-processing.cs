using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDir, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output SVG path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Set up rasterization options for SVG conversion
                    var vectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Configure SVG save options
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorRasterizationOptions
                    };

                    // Save as SVG
                    image.Save(outputPath, svgOptions);
                }

                // Add custom XML namespace to the generated SVG
                XDocument svgDoc = XDocument.Load(outputPath);
                XElement root = svgDoc.Root;
                if (root != null)
                {
                    // Example custom namespace
                    XNamespace customNs = "http://example.com/custom";
                    root.SetAttributeValue(XNamespace.Xmlns + "custom", customNs);
                    svgDoc.Save(outputPath);
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
 * 1. When a developer needs to batch‑convert legacy BMP assets into scalable SVG files for a web UI while preserving exact dimensions using Aspose.Imaging’s rasterization options.
 * 2. When an automation script must generate SVG diagrams from a folder of BMP screenshots and inject a custom XML namespace so downstream XML‑based tools can identify the graphics.
 * 3. When a CI/CD pipeline requires converting design mock‑ups stored as BMP into SVG format for vector‑friendly documentation and adding a namespace for version‑control metadata.
 * 4. When a desktop application processes user‑uploaded BMP images, transforms them into SVG for printing at any resolution, and tags each SVG with a custom namespace for later analytics.
 * 5. When a data‑migration project moves BMP icons into an SVG icon library and needs to programmatically add a namespace to each file to integrate with an existing SVG sprite system.
 */