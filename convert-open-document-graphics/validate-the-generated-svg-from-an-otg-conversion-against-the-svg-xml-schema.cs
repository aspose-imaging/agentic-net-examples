using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;

class SvgValidator
{
    // Holds validation errors encountered during schema validation
    private static readonly List<string> _validationErrors = new List<string>();

    static void Main()
    {
        // Hardcoded input SVG path
        string inputSvgPath = @"C:\Temp\input.svg";

        // Hardcoded output validation report path
        string outputReportPath = @"C:\Temp\validation\report.txt";

        // Input file existence check
        if (!File.Exists(inputSvgPath))
        {
            Console.Error.WriteLine($"File not found: {inputSvgPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputReportPath));

        // Load SVG and validate against the official SVG XSD
        bool isValid = ValidateSvgAgainstSchema(inputSvgPath);

        // Write validation result to the report file
        using (StreamWriter writer = new StreamWriter(outputReportPath, false))
        {
            writer.WriteLine($"SVG Validation Result: {(isValid ? "Valid" : "Invalid")}");
            if (_validationErrors.Count > 0)
            {
                writer.WriteLine("Errors:");
                foreach (string err in _validationErrors)
                {
                    writer.WriteLine(err);
                }
            }
        }

        Console.WriteLine($"Validation completed. Report saved to: {outputReportPath}");
    }

    private static bool ValidateSvgAgainstSchema(string svgPath)
    {
        // Prepare XML schema set; using the W3C SVG 1.1 schema URL
        XmlSchemaSet schemas = new XmlSchemaSet();
        // The schema can be loaded from the web; if offline, replace with a local .xsd file path
        schemas.Add(null, "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.xsd");

        XmlReaderSettings settings = new XmlReaderSettings
        {
            ValidationType = ValidationType.Schema,
            Schemas = schemas,
            DtdProcessing = DtdProcessing.Ignore
        };
        settings.ValidationEventHandler += ValidationEventHandler;

        using (FileStream fs = new FileStream(svgPath, FileMode.Open, FileAccess.Read))
        using (XmlReader reader = XmlReader.Create(fs, settings))
        {
            try
            {
                while (reader.Read()) { /* reading triggers validation */ }
            }
            catch (XmlException ex)
            {
                _validationErrors.Add($"XML parsing error: {ex.Message}");
                return false;
            }
        }

        // If any errors were collected, the SVG is invalid
        return _validationErrors.Count == 0;
    }

    private static void ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        string severity = e.Severity == XmlSeverityType.Error ? "Error" : "Warning";
        _validationErrors.Add($"{severity}: {e.Message}");
    }
}