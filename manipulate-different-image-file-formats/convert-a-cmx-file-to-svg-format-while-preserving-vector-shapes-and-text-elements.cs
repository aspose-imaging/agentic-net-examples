using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input/input.cmx";
            string outputPath = "output/output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                CmxImage cmxImage = (CmxImage)image;

                // Configure SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true // Preserve text as vector shapes
                };

                // Set up CMX rasterization options to retain vector data
                CmxRasterizationOptions rasterOptions = new CmxRasterizationOptions
                {
                    PageSize = cmxImage.Size
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                cmxImage.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert legacy CorelDRAW CMX files to modern SVG format while preserving vector shapes and text as scalable paths for web display.
 * 2. When an application must batch‑process engineering diagrams stored as CMX and output them as SVG for integration into HTML5 dashboards without losing vector fidelity.
 * 3. When a document‑management system requires automated conversion of CMX artwork to SVG so that search engines can index the vector content and maintain searchable text.
 * 4. When a C# service needs to generate printable SVG assets from CMX source files, ensuring text is saved as shapes to avoid font‑dependency issues.
 * 5. When a graphics pipeline has to import CMX drawings and export them as SVG using Aspose.Imaging, preserving exact page size and vector data for downstream CAD tools.
 */