// HOW-TO: Apply 45 Degree Rotation and Gaussian Blur to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Xml.Linq;

namespace SvgProcessor
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output paths
                string inputPath = "input.svg";
                string outputPath = "output.svg";

                // Check if input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                // Load SVG document
                XDocument svgDoc = XDocument.Load(inputPath);
                XNamespace ns = svgDoc.Root?.Name.Namespace ?? XNamespace.None;

                // Ensure <defs> element exists
                XElement defs = svgDoc.Root.Element(ns + "defs");
                if (defs == null)
                {
                    defs = new XElement(ns + "defs");
                    svgDoc.Root.AddFirst(defs);
                }

                // Add Gaussian blur filter
                XElement filter = new XElement(ns + "filter",
                    new XAttribute("id", "gaussianBlur"),
                    new XElement(ns + "feGaussianBlur",
                        new XAttribute("stdDeviation", "5")
                    )
                );
                defs.Add(filter);

                // Create a group that applies rotation and blur
                XElement group = new XElement(ns + "g",
                    new XAttribute("transform", "rotate(45)"),
                    new XAttribute("filter", "url(#gaussianBlur)")
                );

                // Move existing children (except defs) into the group
                var children = svgDoc.Root.Elements();
                var toMove = new System.Collections.Generic.List<XElement>();
                foreach (var elem in children)
                {
                    if (elem != defs)
                    {
                        toMove.Add(elem);
                    }
                }

                foreach (var elem in toMove)
                {
                    elem.Remove();
                    group.Add(elem);
                }

                // Add the group back to the root
                svgDoc.Root.Add(group);

                // Save the modified SVG
                svgDoc.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically add a 45‑degree rotation and soft blur to an SVG logo before embedding it in a web page.
 * 2. When generating dynamic SVG graphics for a dashboard and you want to apply a Gaussian blur filter to highlight rotated elements.
 * 3. When converting vector assets for print and you must apply a blur effect after rotating the artwork to meet design specifications.
 * 4. When creating an SVG‑based animation where objects are rotated and blurred on‑the‑fly using C# without external image editors.
 * 5. When building a server‑side service that processes uploaded SVG files, adds a rotation and blur, and returns the modified file to the client.
 */
