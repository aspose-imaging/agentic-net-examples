// HOW-TO: Convert OTG to SVG and Remove Empty Groups in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.otg";
            string outputPath = "output/output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load OTG image and save as SVG
            using (Image image = Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
            }

            // Load the generated SVG for cleanup
            XDocument svgDoc = XDocument.Load(outputPath);

            // Remove empty <g> elements (no child elements)
            var emptyGroups = svgDoc.Descendants()
                                    .Where(e => e.Name.LocalName == "g" && !e.Elements().Any())
                                    .ToList();
            foreach (var g in emptyGroups)
            {
                g.Remove();
            }

            // Flatten groups that contain only a single child group
            bool changed;
            do
            {
                changed = false;
                var singleChildGroups = svgDoc.Descendants()
                    .Where(e => e.Name.LocalName == "g" &&
                                e.Elements().Count() == 1 &&
                                e.Elements().First().Name.LocalName == "g")
                    .ToList();

                foreach (var g in singleChildGroups)
                {
                    var child = g.Elements().First();
                    g.ReplaceWith(child);
                    changed = true;
                }
            } while (changed);

            // Save the cleaned SVG
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
 * 1. When you need to embed a vector graphic from an OTG file into a web page, you can convert it to SVG and clean up unnecessary groups.
 * 2. When optimizing SVG files for faster browser rendering, removing empty and nested groups reduces file size and complexity.
 * 3. When preparing assets for a design system that requires clean SVG markup, this code transforms OTG drawings into streamlined SVG.
 * 4. When automating batch conversion of legacy OTG illustrations to modern SVG format for use in responsive UI, the script handles conversion and simplification.
 * 5. When integrating vector assets into a C# application that manipulates the SVG DOM, you can first convert OTG and prune redundant group elements to simplify further processing.
 */
