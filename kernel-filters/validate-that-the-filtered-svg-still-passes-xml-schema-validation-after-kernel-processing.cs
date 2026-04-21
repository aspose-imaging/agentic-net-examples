using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.svg";
            string schemaPath = "svg.xsd";

            // Verify input SVG exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Verify schema file exists (optional, but needed for validation)
            if (!File.Exists(schemaPath))
            {
                Console.Error.WriteLine($"File not found: {schemaPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image using Aspose.Imaging
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Save the SVG (could be after processing; here we just copy)
                svgImage.Save(outputPath, new SvgOptions());
            }

            // Validate the saved SVG against the schema
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, schemaPath);

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = schemas;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += (sender, args) =>
            {
                Console.Error.WriteLine($"Validation {args.Severity}: {args.Message}");
            };

            using (XmlReader reader = XmlReader.Create(outputPath, settings))
            {
                while (reader.Read()) { /* just iterate to trigger validation */ }
            }

            Console.WriteLine("SVG validation completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}