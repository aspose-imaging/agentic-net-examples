// HOW-TO: Validate SVG Generated from ODG Conversion Using C# and Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net;
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
            string inputPath = "input.odg";
            string svgPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(svgPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
                image.Save(svgPath, options);
            }

            bool isValid = true;
            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
            settings.ValidationEventHandler += (sender, e) =>
            {
                isValid = false;
                Console.Error.WriteLine($"Validation error: {e.Message}");
            };

            using (WebClient client = new WebClient())
            {
                string xsdContent = client.DownloadString("https://www.w3.org/Graphics/SVG/1.1/DTD/svg11.xsd");
                using (StringReader sr = new StringReader(xsdContent))
                using (XmlReader xr = XmlReader.Create(sr))
                {
                    settings.Schemas.Add(null, xr);
                }
            }

            using (XmlReader reader = XmlReader.Create(svgPath, settings))
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

/*
 * Real-World Use Cases:
 * 1. When a design workflow requires converting OpenDocument graphics (ODG) to scalable SVG files and ensuring they meet the official SVG 1.1 schema before publishing on the web.
 * 2. When an automated build pipeline must verify that SVG assets produced from ODG sources are syntactically correct to prevent rendering errors in browsers.
 * 3. When a SaaS platform generates user‑uploaded ODG diagrams as SVG thumbnails and needs to validate the output against the SVG XSD to guarantee compatibility with downstream image processing tools.
 * 4. When a compliance audit demands that all exported SVG files conform to the W3C SVG schema, and developers use C# with Aspose.Imaging to perform the conversion and validation in a single step.
 * 5. When a desktop application processes batch ODG files, converts them to SVG, and programmatically checks each file’s validity to avoid corrupt files causing crashes in the UI.
 */
