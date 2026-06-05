using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Entry point
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.svg";
        string schemaPath = @"C:\Images\svg.xsd";

        try
        {
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
                // Example kernel processing: no changes, just re-save
                // (Insert any SVG manipulation here if needed)

                // Save the processed SVG
                svgImage.Save(outputPath, new SvgOptions());
            }

            // Validate the saved SVG against the XSD schema
            if (!File.Exists(schemaPath))
            {
                Console.Error.WriteLine($"Schema file not found: {schemaPath}");
                return;
            }

            bool isValid = true;
            ValidationEventHandler validationHandler = (sender, args) =>
            {
                isValid = false;
                Console.Error.WriteLine($"Validation {args.Severity}: {args.Message}");
            };

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, schemaPath);
            settings.ValidationEventHandler += validationHandler;

            using (XmlReader reader = XmlReader.Create(outputPath, settings))
            {
                while (reader.Read()) { /* reading triggers validation */ }
            }

            if (isValid)
            {
                Console.WriteLine("SVG validation succeeded.");
            }
            else
            {
                Console.Error.WriteLine("SVG validation failed.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application generates SVG charts server‑side and must ensure the saved files conform to an SVG XSD before sending them to browsers.
 * 2. When an automated build pipeline processes SVG assets (e.g., applying a custom kernel) and needs to verify that the output still passes XML schema validation to prevent runtime rendering errors.
 * 3. When a desktop C# tool imports user‑provided SVG logos, applies transformations, and validates against a corporate SVG schema to guarantee brand compliance.
 * 4. When a CI/CD workflow for a mobile app resizes and optimizes SVG icons and checks the resulting files against an XSD to catch malformed markup early.
 * 5. When a cloud service that converts SVG to other formats (PNG, PDF) runs a pre‑flight check using XmlReaderSettings to confirm the processed SVG meets the required XML schema standards.
 */