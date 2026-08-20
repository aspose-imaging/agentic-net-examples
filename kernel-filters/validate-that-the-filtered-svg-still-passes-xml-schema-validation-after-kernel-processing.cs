// HOW-TO: Validate Processed SVG Against Schema After Removing Metadata in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Example kernel processing: remove metadata
                svgImage.RemoveMetadata();

                // Save the processed SVG
                svgImage.Save(outputPath, new SvgOptions());

                // Validate the saved SVG against the SVG schema
                ValidateSvg(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ValidateSvg(string svgPath)
    {
        // Path to the SVG 1.1 schema (adjust as needed)
        string schemaPath = @"C:\temp\svg11.xsd";

        // Verify schema file exists
        if (!File.Exists(schemaPath))
        {
            Console.Error.WriteLine($"Schema file not found: {schemaPath}");
            return;
        }

        // Load the schema
        XmlSchemaSet schemas = new XmlSchemaSet();
        schemas.Add(null, schemaPath);

        // Set up validation settings
        XmlReaderSettings settings = new XmlReaderSettings
        {
            ValidationType = ValidationType.Schema,
            Schemas = schemas
        };
        settings.ValidationEventHandler += (sender, e) =>
        {
            Console.Error.WriteLine($"Validation {e.Severity}: {e.Message}");
        };

        // Perform validation
        using (XmlReader reader = XmlReader.Create(svgPath, settings))
        {
            while (reader.Read()) { }
        }

        Console.WriteLine("SVG validation completed.");
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to ensure an SVG edited by your application still conforms to the official SVG 1.1 schema after stripping metadata.
 * 2. When you are building an automated pipeline that cleans SVG files and must verify they remain valid before publishing to a web store.
 * 3. When a regulatory or quality‑assurance process requires that every exported SVG pass XML schema validation after any transformation.
 * 4. When you want to programmatically detect and reject corrupted or non‑compliant SVGs after performing image‑processing operations with Aspose.Imaging.
 * 5. When integrating SVG assets into a larger C# project and you must confirm that kernel processing such as metadata removal does not break the file’s structural integrity.
 */
