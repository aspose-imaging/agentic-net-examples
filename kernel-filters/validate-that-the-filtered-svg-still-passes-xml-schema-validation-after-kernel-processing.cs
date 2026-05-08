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
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.svg";
        string schemaPath = "svg.xsd";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Schema file existence check (optional, but helpful for validation)
        if (!File.Exists(schemaPath))
        {
            Console.Error.WriteLine($"Schema file not found: {schemaPath}");
            return;
        }

        try
        {
            // Load the SVG image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG save options (no special processing)
                SvgOptions svgOptions = new SvgOptions();

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the (potentially processed) SVG to the output path
                image.Save(outputPath, svgOptions);
            }

            // Validate the saved SVG against the provided XSD schema
            bool hasValidationError = false;
            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
            settings.Schemas.Add(null, schemaPath);
            settings.ValidationEventHandler += (sender, args) =>
            {
                Console.Error.WriteLine($"Validation error: {args.Message}");
                hasValidationError = true;
            };

            using (FileStream fs = File.OpenRead(outputPath))
            using (XmlReader reader = XmlReader.Create(fs, settings))
            {
                while (reader.Read()) { }
            }

            if (!hasValidationError)
            {
                Console.WriteLine("SVG validation passed.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}