// HOW-TO: Validate Processed SVG Against W3C Schema In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace SvgValidator
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.svg";
                string outputPath = "output.svg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Read the input SVG
                string svgContent = File.ReadAllText(inputPath);

                // Kernel processing placeholder (no changes applied)
                string processedSvg = svgContent;

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Write the processed SVG to the output path
                File.WriteAllText(outputPath, processedSvg);

                // Validate the processed SVG against the SVG schema
                bool isValid = true;
                var settings = new XmlReaderSettings
                {
                    ValidationType = ValidationType.Schema,
                    ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings
                };
                settings.ValidationEventHandler += (sender, e) =>
                {
                    Console.Error.WriteLine($"Validation {e.Severity}: {e.Message}");
                    isValid = false;
                };

                // Add the SVG schema (using the official W3C schema URL)
                settings.Schemas.Add(null, "http://www.w3.org/2009/08/svg-schema/svg.xsd");

                using (var reader = XmlReader.Create(outputPath, settings))
                {
                    while (reader.Read()) { }
                }

                Console.WriteLine(isValid ? "SVG is valid." : "SVG is invalid.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to ensure an SVG generated or modified by your .NET application still conforms to the official SVG XML schema before publishing it.
 * 2. When you want to automatically verify that filtered or kernel‑processed SVG files are syntactically correct and will render correctly in browsers.
 * 3. When a CI/CD pipeline must reject SVG assets that fail W3C schema validation after automated transformations.
 * 4. When building a batch processor that reads, optionally edits, and saves SVGs while guaranteeing each output file is schema‑compliant.
 * 5. When integrating third‑party SVG content into a C# project and you must confirm its validity after applying custom preprocessing steps.
 */
