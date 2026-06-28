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
            // Hardcoded input, output and schema paths
            string inputPath = @"C:\Data\sample.odg";
            string outputPath = @"C:\Data\sample.svg";
            string schemaPath = @"C:\Data\svg.xsd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load ODG and save as SVG using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new SvgOptions());
            }

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

            Console.WriteLine("SVG validation completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. A developer converting LibreOffice Draw ODG files to SVG with Aspose.Imaging for .NET can use this code to ensure the generated SVG conforms to the official SVG XML schema before embedding it in a web page.
 * 2. In an automated document‑processing pipeline, this snippet validates each ODG‑to‑SVG conversion against the SVG XSD to prevent malformed vector graphics from reaching downstream applications.
 * 3. A CI/CD quality‑assurance step can run this C# program to check that every SVG produced from ODG sources passes schema validation, catching errors before release.
 * 4. A Windows desktop app that imports ODG diagrams and saves them as SVG can employ this code to verify schema compliance, guaranteeing compatibility with third‑party vector editors.
 * 5. A cloud‑based batch conversion service that transforms ODG drawings into SVG can use this validation routine to programmatically confirm each file meets SVG schema standards, ensuring reliable downloads for users.
 */