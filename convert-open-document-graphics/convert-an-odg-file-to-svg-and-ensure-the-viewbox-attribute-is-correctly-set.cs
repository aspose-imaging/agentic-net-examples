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
        string inputPath = @"C:\Temp\sample.odg";
        string outputPath = @"C:\Temp\sample.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Prepare SVG export options with proper page size
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = odgImage.Size
                }
            };

            // Save as SVG
            odgImage.Save(outputPath, svgOptions);
        }

        // Load the generated SVG to ensure viewBox attribute is set correctly
        XDocument svgDoc = XDocument.Load(outputPath);
        XElement root = svgDoc.Root;
        if (root != null)
        {
            // Set viewBox to "0 0 width height"
            // Width and height are taken from the SVG's width/height attributes if present,
            // otherwise fallback to the original image dimensions.
            int width = (int)(root.Attribute("width")?.Value.Split(' ')[0] != null
                ? double.Parse(root.Attribute("width").Value)
                : 0);
            int height = (int)(root.Attribute("height")?.Value.Split(' ')[0] != null
                ? double.Parse(root.Attribute("height").Value)
                : 0);

            // If width/height attributes are missing, use the original ODG dimensions
            if (width == 0 || height == 0)
            {
                // Load ODG again just to get dimensions (lightweight)
                using (Image img = Image.Load(inputPath))
                {
                    width = img.Width;
                    height = img.Height;
                }
            }

            root.SetAttributeValue("viewBox", $"0 0 {width} {height}");
        }

        // Save the corrected SVG
        svgDoc.Save(outputPath);
    }
}