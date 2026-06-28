using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class SimpleSvgCallback : SvgResourceKeeperCallback
{
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Load SVG XML from the byte array
        XDocument doc;
        using (var ms = new MemoryStream(htmlData))
        {
            doc = XDocument.Load(ms);
        }

        // Flatten all <g> elements by moving their children up and removing the group
        var groups = doc.Descendants()
                        .Where(e => e.Name.LocalName == "g")
                        .ToList(); // materialize to avoid modification during iteration

        foreach (var g in groups)
        {
            var parent = g.Parent;
            if (parent != null)
            {
                // Insert child nodes before the group element
                foreach (var node in g.Nodes().ToList())
                {
                    parent.Add(node);
                }
            }
            g.Remove();
        }

        // Ensure the output directory exists
        var outDir = Path.GetDirectoryName(suggestedFileName);
        if (!string.IsNullOrEmpty(outDir))
        {
            Directory.CreateDirectory(outDir);
        }

        // Save the cleaned SVG
        doc.Save(suggestedFileName);
        return suggestedFileName;
    }
}

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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export with custom callback to simplify groups
                var svgOptions = new SvgOptions
                {
                    Callback = new SimpleSvgCallback()
                };

                // Save as SVG; the callback will handle post‑processing
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
 * 1. When a developer needs to embed LibreOffice Draw diagrams (ODG) into a web page that only supports SVG, this code converts the file and flattens group elements for faster browser rendering.
 * 2. When preparing technical documentation that includes vector graphics, a developer can convert ODG charts to clean SVG files without nested <g> tags to reduce file size and improve PDF generation compatibility.
 * 3. When optimizing SVG assets for responsive UI components, a developer can use this code to strip unnecessary group elements from ODG‑derived SVGs, ensuring smoother scaling and animation in C# WPF applications.
 * 4. When automating a batch process that extracts vector icons from an ODG library for a mobile app, the code enables conversion to SVG and simplifies the markup for easier CSS styling.
 * 5. When migrating legacy design assets stored as ODG into a modern content management system that stores SVGs, a developer can run this conversion to produce clean, group‑free SVG files that are easier to index and search.
 */