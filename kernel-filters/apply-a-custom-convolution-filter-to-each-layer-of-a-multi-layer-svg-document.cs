// HOW-TO: Apply Custom Convolution Filter to All Layers of SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the SVG document
            XDocument svgDoc = XDocument.Load(inputPath);
            XNamespace svgNs = "http://www.w3.org/2000/svg";

            // Define a custom convolution filter
            // Adjust the kernelMatrix as needed for your custom filter
            string filterId = "customConvolve";
            XElement defsElement = svgDoc.Root.Element(svgNs + "defs");
            if (defsElement == null)
            {
                defsElement = new XElement(svgNs + "defs");
                svgDoc.Root.AddFirst(defsElement);
            }

            // Remove any existing filter with the same ID to avoid duplicates
            XElement existingFilter = defsElement.Element(svgNs + "filter");
            if (existingFilter != null && (string)existingFilter.Attribute("id") == filterId)
            {
                existingFilter.Remove();
            }

            XElement filterElement = new XElement(svgNs + "filter",
                new XAttribute("id", filterId),
                new XElement(svgNs + "feConvolveMatrix",
                    new XAttribute("order", "3"),
                    new XAttribute("kernelMatrix", "0 -1 0 -1 5 -1 0 -1 0"),
                    new XAttribute("divisor", "1"),
                    new XAttribute("bias", "0"),
                    new XAttribute("targetX", "1"),
                    new XAttribute("targetY", "1"),
                    new XAttribute("edgeMode", "duplicate"),
                    new XAttribute("preserveAlpha", "true")
                )
            );

            defsElement.Add(filterElement);

            // Apply the filter to each top‑level layer (<g> elements)
            foreach (XElement layer in svgDoc.Root.Elements(svgNs + "g"))
            {
                // Add or replace the filter attribute
                layer.SetAttributeValue("filter", $"url(#{filterId})");
            }

            // Save the modified SVG
            svgDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to sharpen or edge‑detect every group layer in an SVG before rasterizing it.
 * 2. When you want to programmatically add a custom convolution filter to an existing multi‑layer SVG without manually editing the file.
 * 3. When you must ensure the same convolution effect is applied consistently across all layers of a complex SVG icon set.
 * 4. When you are automating a pipeline that processes SVG assets and requires a custom kernel for branding or visual style.
 * 5. When you need to replace or update an existing filter definition in an SVG file to avoid duplicate IDs during batch processing.
 */
