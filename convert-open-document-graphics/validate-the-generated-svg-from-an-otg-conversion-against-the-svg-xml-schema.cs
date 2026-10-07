// HOW-TO: Validate SVG Generated From OTG Conversion Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string otgPath = "input.otg";
            string svgPath = "output.svg";

            // Check input file existence
            if (!File.Exists(otgPath))
            {
                Console.Error.WriteLine($"File not found: {otgPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(svgPath) ?? ".");

            // Convert OTG to SVG using Aspose.Imaging
            using (Image image = Image.Load(otgPath))
            {
                var svgOptions = new SvgOptions();
                image.Save(svgPath, svgOptions);
            }

            // Validate the generated SVG against the SVG XML schema
            bool isValid = true;
            string schemaUrl = "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.xsd";

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, schemaUrl);

            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                Schemas = schemas,
                DtdProcessing = DtdProcessing.Ignore
            };
            settings.ValidationEventHandler += (sender, e) =>
            {
                isValid = false;
                Console.Error.WriteLine($"Validation {e.Severity}: {e.Message}");
            };

            using (XmlReader reader = XmlReader.Create(svgPath, settings))
            {
                while (reader.Read()) { }
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
 * 1. When you need to ensure an OTG file converted to SVG complies with the official SVG 1.1 schema before publishing on the web.
 * 2. When a graphics pipeline requires automated validation of SVG output to catch malformed markup early in a CI build.
 * 3. When integrating Aspose.Imaging into a C# application that converts legacy vector formats to SVG and must guarantee compatibility with browsers.
 * 4. When generating SVG assets from OTG for a mobile app and you want to verify they meet XML schema standards to avoid runtime rendering errors.
 * 5. When processing batch conversions of design files and need to log validation failures for quality control and troubleshooting.
 */
