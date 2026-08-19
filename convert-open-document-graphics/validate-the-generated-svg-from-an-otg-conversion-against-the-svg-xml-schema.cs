// HOW-TO: Validate SVG Generated From OTG Conversion Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var otgOptions = new OtgRasterizationOptions();
                otgOptions.PageSize = image.Size;

                var svgOptions = new SvgOptions();
                svgOptions.VectorRasterizationOptions = otgOptions;

                image.Save(outputPath, svgOptions);
            }

            var errors = new System.Collections.Generic.List<string>();
            var settings = new System.Xml.XmlReaderSettings();
            settings.ValidationType = System.Xml.ValidationType.Schema;
            settings.Schemas.Add(null, "http://www.w3.org/2000/svg");
            settings.ValidationEventHandler += (sender, e) => { errors.Add(e.Message); };

            using (var reader = System.Xml.XmlReader.Create(outputPath, settings))
            {
                while (reader.Read()) { }
            }

            if (errors.Count == 0)
            {
                Console.WriteLine("SVG validation succeeded.");
            }
            else
            {
                Console.WriteLine("SVG validation failed:");
                foreach (var err in errors)
                {
                    Console.WriteLine(err);
                }
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
 * 1. When you need to ensure that SVG files created from OTG drawings comply with the official SVG XML schema before publishing them on a website.
 * 2. When an automated pipeline must convert legacy OTG vector graphics to SVG and verify the output to prevent rendering errors in browsers.
 * 3. When a desktop application processes user‑uploaded OTG files and must validate the resulting SVG to guarantee compatibility with downstream SVG editors.
 * 4. When you are integrating Aspose.Imaging into a C# service that generates SVG reports from OTG sources and requires schema validation for regulatory compliance.
 * 5. When a CI/CD build step needs to programmatically confirm that each OTG‑to‑SVG conversion produces a standards‑compliant SVG file.
 */
