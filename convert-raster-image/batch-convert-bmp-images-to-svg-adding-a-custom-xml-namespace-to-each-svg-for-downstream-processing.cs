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
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDir, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output SVG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image and convert to SVG
                using (Image image = Image.Load(inputPath))
                {
                    var vectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorRasterizationOptions
                    };

                    image.Save(outputPath, svgOptions);
                }

                // Add custom XML namespace to the generated SVG
                XDocument xdoc = XDocument.Load(outputPath);
                XNamespace customNs = "http://example.com/custom";
                XElement root = xdoc.Root;
                if (root != null && root.Attribute(XNamespace.Xmlns + "custom") == null)
                {
                    root.SetAttributeValue(XNamespace.Xmlns + "custom", customNs);
                }
                xdoc.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}