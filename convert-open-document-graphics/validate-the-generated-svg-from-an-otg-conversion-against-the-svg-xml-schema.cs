using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG path
        string inputSvgPath = @"C:\temp\input.svg";
        // Hardcoded SVG schema (XSD) path
        string schemaPath = @"C:\temp\svg.xsd";
        // Hardcoded output validation report path
        string outputReportPath = @"C:\temp\validation_report.txt";

        // Verify input SVG exists
        if (!File.Exists(inputSvgPath))
        {
            Console.Error.WriteLine($"File not found: {inputSvgPath}");
            return;
        }

        // Verify schema file exists
        if (!File.Exists(schemaPath))
        {
            Console.Error.WriteLine($"File not found: {schemaPath}");
            return;
        }

        // Ensure the directory for the report exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputReportPath));

        bool isValid = true;

        // Set up XML schema validation settings
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas.Add(null, schemaPath);
        settings.ValidationType = ValidationType.Schema;
        settings.ValidationEventHandler += (sender, e) =>
        {
            // Record any validation errors or warnings
            isValid = false;
            File.AppendAllText(outputReportPath,
                $"Validation {e.Severity}: {e.Message}{Environment.NewLine}");
        };

        // Perform schema validation on the SVG file
        using (XmlReader reader = XmlReader.Create(inputSvgPath, settings))
        {
            while (reader.Read()) { }
        }

        // Additionally, attempt to load the SVG with Aspose.Imaging to ensure it is a well‑formed SVG image
        try
        {
            using (SvgImage svgImage = new SvgImage(inputSvgPath))
            {
                // No further processing required; successful construction means the SVG is readable
            }
        }
        catch (Exception ex)
        {
            isValid = false;
            File.AppendAllText(outputReportPath,
                $"Aspose.Imaging loading error: {ex.Message}{Environment.NewLine}");
        }

        // Write overall validation result
        File.AppendAllText(outputReportPath,
            $"Overall validation result: {(isValid ? "Valid" : "Invalid")}{Environment.NewLine}");
    }
}