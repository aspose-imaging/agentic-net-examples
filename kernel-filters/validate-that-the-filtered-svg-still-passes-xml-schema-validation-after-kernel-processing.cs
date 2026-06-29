using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using System.Xml;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.svg";
            string outputPath = "output.svg";
            string schemaPath = "svg.xsd";

            // Input existence checks
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            if (!File.Exists(schemaPath))
            {
                Console.Error.WriteLine($"Schema file not found: {schemaPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load SVG, optionally process, then save
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // No processing performed in this example
                svgImage.Save(outputPath, new SvgOptions());
            }

            // Validate the saved SVG against the provided XSD schema
            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
            settings.Schemas.Add(null, schemaPath);
            settings.ValidationEventHandler += (sender, e) =>
            {
                Console.Error.WriteLine($"Validation {e.Severity}: {e.Message}");
            };

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
 * 1. When a web application generates or modifies SVG graphics on the server using Aspose.Imaging for .NET and must ensure the output conforms to the official SVG XSD schema before sending it to browsers.
 * 2. When an automated build pipeline processes SVG assets, applies transformations, and needs to verify that the saved SVG files still pass XML schema validation to prevent broken images in the final product.
 * 3. When a desktop tool imports user‑provided SVG files, optionally edits them with Aspose.Imaging, and must validate the resulting SVG against a custom schema to guarantee compatibility with downstream vector‑editing software.
 * 4. When a content management system stores SVG icons, runs a kernel filter to strip unwanted elements, and requires schema validation to avoid storing malformed XML that could cause rendering errors.
 * 5. When a CI/CD test suite includes a step that loads an SVG, saves it with SvgOptions, and checks the saved file against an XSD to catch regressions in the Aspose.Imaging SVG processing pipeline.
 */