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
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    }
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            // Load generated SVG, remove empty <g> elements, and overwrite the file
            XDocument svgDoc = XDocument.Load(outputPath);
            RemoveEmptyGroups(svgDoc.Root);
            svgDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Recursively removes <g> elements that have no child elements (or only whitespace)
    static void RemoveEmptyGroups(XElement element)
    {
        if (element == null) return;

        // Process child groups first
        var groups = element.Elements().Where(e => e.Name.LocalName == "g").ToList();
        foreach (var grp in groups)
        {
            RemoveEmptyGroups(grp);
        }

        // After processing children, remove groups that are empty
        foreach (var grp in groups)
        {
            bool hasNonEmptyChild = grp.Elements().Any(e => e.Name.LocalName != "g" || !string.IsNullOrWhiteSpace(e.Value));
            if (!hasNonEmptyChild && !grp.Elements().Any())
            {
                grp.Remove();
            }
        }
    }
}