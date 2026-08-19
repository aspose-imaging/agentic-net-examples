// HOW-TO: Validate ODG to SVG Conversion Against SVG Schema in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Schema;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.odg";
        string outputPath = @"C:\temp\output.svg";

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

            // Load ODG image and convert to SVG
            using (Image image = Image.Load(inputPath))
            {
                var vectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = vectorRasterizationOptions
                };

                image.Save(outputPath, svgOptions);
            }

            // Validate generated SVG against the SVG XML schema
            var schemaSet = new XmlSchemaSet();

            // Download SVG schema from W3C
            using (var client = new WebClient())
            {
                string schemaContent = client.DownloadString("https://www.w3.org/2000/svg");
                using (var schemaReader = new StringReader(schemaContent))
                {
                    schemaSet.Add(null, XmlReader.Create(schemaReader));
                }
            }

            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                Schemas = schemaSet
            };

            bool hasErrors = false;
            settings.ValidationEventHandler += (sender, e) =>
            {
                Console.Error.WriteLine($"Validation error: {e.Message}");
                hasErrors = true;
            };

            using (var reader = XmlReader.Create(outputPath, settings))
            {
                while (reader.Read()) { }
            }

            if (!hasErrors)
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

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically convert OpenDocument graphics (ODG) files to SVG for web display while ensuring the output complies with the official SVG XML schema.
 * 2. When an automated document processing pipeline must verify that generated SVG files are standards‑compliant before they are sent to a third‑party service.
 * 3. When you are building a C# application that imports ODG assets and must guarantee that the resulting SVG can be rendered correctly in browsers and vector editors.
 * 4. When a quality‑assurance tool needs to detect schema violations in SVG files produced from legacy ODG drawings.
 * 5. When you want to integrate SVG validation into a CI/CD workflow to prevent non‑conforming SVG assets from being deployed.
 */
