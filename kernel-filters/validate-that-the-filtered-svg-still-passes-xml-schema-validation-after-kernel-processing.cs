using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Hardcoded paths
    private const string InputSvgPath = @"C:\Images\input.svg";
    private const string OutputSvgPath = @"C:\Images\output.svg";
    private const string SchemaPath = @"C:\Images\svg.xsd";

    static void Main()
    {
        try
        {
            // Verify input SVG exists
            if (!File.Exists(InputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {InputSvgPath}");
                return;
            }

            // Verify schema file exists (optional, but validation needs it)
            if (!File.Exists(SchemaPath))
            {
                Console.Error.WriteLine($"Schema file not found: {SchemaPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(OutputSvgPath));

            // Load the SVG image
            using (SvgImage svgImage = new SvgImage(InputSvgPath))
            {
                // Example kernel processing could be placed here.
                // For demonstration we simply save the image unchanged.

                // Save the SVG to the output path
                svgImage.Save(OutputSvgPath);
            }

            // Validate the saved SVG against the XSD schema
            bool isValid = true;
            ValidationEventHandler validationHandler = (sender, args) =>
            {
                isValid = false;
                Console.Error.WriteLine($"Validation {args.Severity}: {args.Message}");
            };

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, SchemaPath);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += validationHandler;

            using (FileStream fs = File.OpenRead(OutputSvgPath))
            using (XmlReader reader = XmlReader.Create(fs, settings))
            {
                while (reader.Read()) { } // Parse the document
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
 * 1. When a web application generates SVG charts dynamically and must ensure the output conforms to an SVG XSD before sending to browsers.
 * 2. When an automated build pipeline processes SVG assets with custom kernels and needs to verify that the transformed files remain schema‑compliant to avoid runtime rendering errors.
 * 3. When a desktop publishing tool imports user‑provided SVG logos, applies filters using Aspose.Imaging, and validates the result against a corporate SVG schema to enforce branding guidelines.
 * 4. When a cloud‑based image conversion service converts SVG to raster formats and wants to log any schema violations after kernel processing to maintain data quality.
 * 5. When a CI/CD test suite runs regression tests on SVG filters and uses the code to confirm that each filtered SVG still passes XML schema validation, preventing broken graphics in production.
 */