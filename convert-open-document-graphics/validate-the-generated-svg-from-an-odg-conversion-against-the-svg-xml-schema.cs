using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using System.Xml;
using System.Xml.Schema;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\sample.odg";
            string outputPath = @"C:\Data\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load ODG and convert to SVG
            using (Image image = Image.Load(inputPath))
            {
                var vectorOptions = new SvgRasterizationOptions { PageSize = image.Size };
                var svgOptions = new SvgOptions { VectorRasterizationOptions = vectorOptions };
                image.Save(outputPath, svgOptions);
            }

            // Path to SVG XML schema (XSD)
            string schemaPath = @"C:\Data\svg.xsd";

            // Verify schema file exists
            if (!File.Exists(schemaPath))
            {
                Console.Error.WriteLine($"Schema file not found: {schemaPath}");
                return;
            }

            // Prepare schema set
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, schemaPath);

            // Configure XML reader for validation
            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                Schemas = schemas
            };
            settings.ValidationEventHandler += (sender, e) =>
            {
                Console.Error.WriteLine($"Validation {e.Severity}: {e.Message}");
            };

            // Validate the generated SVG
            using (XmlReader reader = XmlReader.Create(outputPath, settings))
            {
                while (reader.Read()) { }
            }

            Console.WriteLine("SVG validation completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}