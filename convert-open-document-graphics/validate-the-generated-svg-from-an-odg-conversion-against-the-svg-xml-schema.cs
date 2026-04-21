using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.odg";
        string outputPath = @"C:\temp\output.svg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image and save it as SVG
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG export options
            var svgOptions = new SvgOptions
            {
                // Use default rasterization options; can be customized if needed
                VectorRasterizationOptions = new SvgRasterizationOptions()
            };

            image.Save(outputPath, svgOptions);
        }

        // Validate the generated SVG against the SVG XML schema
        ValidateSvg(outputPath);
    }

    static void ValidateSvg(string svgFilePath)
    {
        // Load the SVG schema (W3C SVG 1.1 schema)
        var schemas = new XmlSchemaSet();
        // The schema is retrieved from the official W3C location.
        // If the environment cannot access the internet, replace the URL with a local copy.
        schemas.Add("http://www.w3.org/2000/svg", "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.xsd");

        var settings = new XmlReaderSettings
        {
            ValidationType = ValidationType.Schema,
            Schemas = schemas,
            DtdProcessing = DtdProcessing.Ignore
        };
        settings.ValidationEventHandler += ValidationCallback;

        using (var reader = XmlReader.Create(svgFilePath, settings))
        {
            try
            {
                while (reader.Read()) { /* reading triggers validation */ }
                Console.WriteLine("SVG validation succeeded.");
            }
            catch (XmlException ex)
            {
                Console.Error.WriteLine($"XML parsing error: {ex.Message}");
            }
        }
    }

    static void ValidationCallback(object sender, ValidationEventArgs e)
    {
        // Report validation warnings and errors
        string severity = e.Severity == XmlSeverityType.Error ? "Error" : "Warning";
        Console.Error.WriteLine($"{severity}: {e.Message}");
    }
}