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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string tempSvgPath = @"C:\Images\temp_modified.svg";
        string outputPdfPath = @"C:\Images\output.pdf";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempSvgPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Load the original SVG as XML
        XDocument svgDoc = XDocument.Load(inputPath);

        // Apply a custom dash pattern to all <path> elements
        var pathElements = svgDoc.Descendants()
                                 .Where(e => e.Name.LocalName.Equals("path", StringComparison.OrdinalIgnoreCase));

        foreach (var pathElem in pathElements)
        {
            // Set a dash pattern (e.g., 5 units dash, 5 units gap)
            pathElem.SetAttributeValue("stroke-dasharray", "5,5");

            // Ensure a stroke color is defined; default to black if missing
            if (pathElem.Attribute("stroke") == null)
            {
                pathElem.SetAttributeValue("stroke", "black");
            }
        }

        // Save the modified SVG to a temporary file
        svgDoc.Save(tempSvgPath);

        // Load the modified SVG with Aspose.Imaging
        using (Image svgImage = Image.Load(tempSvgPath))
        {
            // Export to PDF
            var pdfOptions = new PdfOptions();
            svgImage.Save(outputPdfPath, pdfOptions);
        }
    }
}