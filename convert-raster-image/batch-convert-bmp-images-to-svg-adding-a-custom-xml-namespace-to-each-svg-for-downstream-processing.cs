// HOW-TO: Batch Convert BMP Images to SVG with Custom XML Namespace in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Custom XML namespace to add
            string customPrefix = "custom";
            string customNamespace = "http://example.com/custom";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string bmpPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(bmpPath))
                {
                    Console.Error.WriteLine($"File not found: {bmpPath}");
                    continue;
                }

                // Prepare output SVG path
                string outputSvgPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(bmpPath) + ".svg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));

                // Load BMP image and save as SVG
                using (Image image = Image.Load(bmpPath))
                {
                    var svgOptions = new SvgOptions();
                    image.Save(outputSvgPath, svgOptions);
                }

                // Load the generated SVG and add the custom namespace
                XDocument svgDoc = XDocument.Load(outputSvgPath);
                XElement root = svgDoc.Root;
                if (root != null)
                {
                    XNamespace ns = customNamespace;
                    root.Add(new XAttribute(XNamespace.Xmlns + customPrefix, customNamespace));
                }
                svgDoc.Save(outputSvgPath);
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
 * 1. When you need to convert a large collection of legacy BMP graphics to scalable SVG files for web display while embedding a custom XML namespace for later data extraction.
 * 2. When an automated build pipeline must generate SVG assets from BMP sources and tag them with a company‑specific namespace to be recognized by downstream XML‑based tools.
 * 3. When a desktop application processes user‑uploaded BMP images and must output SVGs that include a custom namespace so that a separate reporting module can identify and manipulate those elements.
 * 4. When migrating a design system from raster to vector format and you require batch conversion with Aspose.Imaging while preserving metadata through a custom XML namespace for integration with a vector editing workflow.
 * 5. When creating a batch script that prepares SVG icons from BMP files for a mobile app and needs to add a custom namespace so the app’s rendering engine can apply theme‑specific attributes.
 */
