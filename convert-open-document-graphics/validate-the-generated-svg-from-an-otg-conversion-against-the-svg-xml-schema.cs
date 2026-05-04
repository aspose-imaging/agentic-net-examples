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
            // Hardcoded paths
            string otgInputPath = @"C:\temp\input.otg";
            string svgOutputPath = @"C:\temp\output.svg";
            string svgSchemaPath = @"C:\schemas\svg.xsd";

            // Verify input OTG file exists
            if (!File.Exists(otgInputPath))
            {
                Console.Error.WriteLine($"File not found: {otgInputPath}");
                return;
            }

            // Verify SVG schema file exists
            if (!File.Exists(svgSchemaPath))
            {
                Console.Error.WriteLine($"File not found: {svgSchemaPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

            // Load the OTG image
            using (Image image = Image.Load(otgInputPath))
            {
                // Prepare rasterization options (use image size if available)
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Prepare SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as SVG
                image.Save(svgOutputPath, svgOptions);
            }

            // Validate the generated SVG against the schema
            bool validationFailed = false;
            var settings = new XmlReaderSettings();
            settings.Schemas.Add(null, svgSchemaPath);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += (sender, args) =>
            {
                validationFailed = true;
                Console.Error.WriteLine($"Validation {args.Severity}: {args.Message}");
            };

            using (var reader = XmlReader.Create(svgOutputPath, settings))
            {
                while (reader.Read()) { /* reading triggers validation */ }
            }

            if (validationFailed)
            {
                Console.Error.WriteLine("SVG validation failed.");
            }
            else
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