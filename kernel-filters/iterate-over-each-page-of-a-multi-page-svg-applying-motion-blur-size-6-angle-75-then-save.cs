// HOW-TO: Apply Motion Blur Filter to All Pages of Multi‑Page SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input/input.svg";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            XDocument doc = XDocument.Load(inputPath);
            XNamespace ns = "http://www.w3.org/2000/svg";

            // Ensure <defs> exists
            XElement defs = doc.Root.Element(ns + "defs");
            if (defs == null)
            {
                defs = new XElement(ns + "defs");
                doc.Root.AddFirst(defs);
            }

            // Create motion blur filter
            XElement filter = new XElement(ns + "filter",
                new XAttribute("id", "motionBlur"),
                new XElement(ns + "feMotionBlur",
                    new XAttribute("stdDeviation", "6"),
                    new XAttribute("angle", "75")
                )
            );
            defs.Add(filter);

            // Apply filter to each <svg> element (including root)
            foreach (XElement svgElem in doc.Descendants(ns + "svg"))
            {
                svgElem.SetAttributeValue("filter", "url(#motionBlur)");
            }

            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to add a consistent motion‑blur effect to every layer of a multi‑page SVG diagram generated from CAD software.
 * 2. When generating animated web graphics and you want to apply the same blur filter across all SVG frames before exporting.
 * 3. When processing a batch of SVG icons that contain nested <svg> elements and you must ensure each icon receives a uniform blur for a stylized UI theme.
 * 4. When converting a multi‑page SVG brochure into a blurred background for a presentation and you require the filter to be applied programmatically in C#.
 * 5. When automating the preparation of SVG assets for a game and you need to apply a 6‑pixel, 75‑degree motion blur to every SVG page to simulate speed.
 */
