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
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options for SVG export
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Save the image as SVG
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                image.Save(outputPath, svgOptions);
            }

            // Validate the generated SVG against an XSD schema
            // Assumes an SVG schema file named "svg.xsd" is located alongside the executable
            string schemaPath = "svg.xsd";
            if (!File.Exists(schemaPath))
            {
                Console.Error.WriteLine($"Schema file not found: {schemaPath}");
                return;
            }

            var settings = new XmlReaderSettings();
            var schemas = new XmlSchemaSet();
            schemas.Add(null, schemaPath);
            settings.Schemas = schemas;
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

            bool validationFailed = false;
            settings.ValidationEventHandler += (sender, e) =>
            {
                Console.Error.WriteLine($"Validation {e.Severity}: {e.Message}");
                validationFailed = true;
            };

            using (var reader = XmlReader.Create(outputPath, settings))
            {
                while (reader.Read()) { }
            }

            if (validationFailed)
            {
                Console.Error.WriteLine("SVG validation failed.");
            }
            else
            {
                Console.WriteLine("SVG validation succeeded.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}