using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Entry point
    static void Main()
    {
        // Hardcoded input, output and schema paths
        string inputPath = @"C:\temp\input.odg";
        string outputPath = @"C:\temp\output.svg";
        string schemaPath = @"C:\temp\svg.xsd";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG (or any vector) image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG export options
            var svgOptions = new SvgOptions
            {
                // Use default rasterization options; can be customized if needed
                VectorRasterizationOptions = new SvgRasterizationOptions()
            };

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }

        // Validate the generated SVG against the provided XSD schema
        ValidateSvg(outputPath, schemaPath);
    }

    // Performs XML schema validation on an SVG file
    static void ValidateSvg(string svgFilePath, string xsdFilePath)
    {
        // Schema file existence check
        if (!File.Exists(xsdFilePath))
        {
            Console.Error.WriteLine($"File not found: {xsdFilePath}");
            return;
        }

        // Prepare schema set
        var schemas = new XmlSchemaSet();
        schemas.Add(null, xsdFilePath);

        // Configure XML reader settings for validation
        var settings = new XmlReaderSettings
        {
            ValidationType = ValidationType.Schema,
            Schemas = schemas,
            DtdProcessing = DtdProcessing.Prohibit
        };
        settings.ValidationEventHandler += ValidationCallback;

        // Read and validate the SVG file
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

    // Handles validation errors and warnings
    static void ValidationCallback(object sender, ValidationEventArgs e)
    {
        string message = $"SVG validation {e.Severity}: {e.Message}";
        if (e.Severity == XmlSeverityType.Error)
            Console.Error.WriteLine(message);
        else
            Console.WriteLine(message);
    }
}