using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.otg";
        string outputPath = @"C:\Temp\output.svg";

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
            var svgOptions = new SvgOptions();
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }

        // Load the generated SVG for post‑processing
        XDocument svgDoc = XDocument.Load(outputPath);

        // Simplify unnecessary <g> elements
        SimplifyGroups(svgDoc.Root);

        // Overwrite the SVG file with the simplified version
        svgDoc.Save(outputPath);
    }

    // Recursively removes <g> elements that have no attributes and a single child,
    // replacing the group with its child element.
    static void SimplifyGroups(XElement element)
    {
        if (element == null) return;

        // Process a copy of the child elements list to avoid modification issues
        var children = element.Elements().ToList();

        foreach (var child in children)
        {
            SimplifyGroups(child);
        }

        // After processing descendants, check if current element is a <g> that can be flattened
        if (element.Name.LocalName == "g" &&
            !element.HasAttributes &&
            element.Elements().Count() == 1)
        {
            XElement inner = element.Elements().First();

            // Preserve any whitespace or formatting by inserting the inner element before the group
            element.ReplaceWith(inner);
        }
    }
}