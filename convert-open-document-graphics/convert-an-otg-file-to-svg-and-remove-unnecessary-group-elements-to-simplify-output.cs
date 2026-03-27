using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class SimplifySvgCallback : SvgResourceKeeperCallback
{
    private readonly string _outputPath;

    public SimplifySvgCallback(string outputPath)
    {
        _outputPath = outputPath;
    }

    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Load the SVG XML from the byte array
        XDocument doc;
        using (var ms = new MemoryStream(htmlData))
        {
            doc = XDocument.Load(ms);
        }

        // Recursively remove empty <g> elements (no child elements and no meaningful text)
        bool removed;
        do
        {
            removed = false;
            var emptyGroups = doc.Descendants()
                                 .Where(e => e.Name.LocalName == "g" && !e.HasElements && string.IsNullOrWhiteSpace(e.Value))
                                 .ToList();

            foreach (var g in emptyGroups)
            {
                g.Remove();
                removed = true;
            }
        } while (removed);

        // Save the cleaned SVG to the desired output path
        doc.Save(_outputPath);
        return _outputPath;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.svg";

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
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                },
                // Attach callback to clean up the SVG
                Callback = new SimplifySvgCallback(outputPath)
            };

            // Save as SVG (callback will handle final writing)
            image.Save(outputPath, svgOptions);
        }
    }
}