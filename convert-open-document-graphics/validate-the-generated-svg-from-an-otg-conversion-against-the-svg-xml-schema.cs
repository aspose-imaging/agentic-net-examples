using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input SVG path
            string inputPath = @"C:\temp\input.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Ensure the loaded image is an SVG
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("The provided file is not a valid SVG image.");
                    return;
                }

                // Export the SVG content to a string (using a memory stream)
                string svgContent;
                using (MemoryStream ms = new MemoryStream())
                {
                    // Save with default SvgOptions to preserve original XML
                    svgImage.Save(ms, new SvgOptions());
                    svgContent = Encoding.UTF8.GetString(ms.ToArray());
                }

                // Prepare XML schema validation
                XmlSchemaSet schemas = new XmlSchemaSet();

                // Minimal SVG 1.1 schema (embedded). For full validation, replace with the complete schema.
                const string svgSchema = @"
<xs:schema xmlns:xs='http://www.w3.org/2001/XMLSchema'
           targetNamespace='http://www.w3.org/2000/svg'
           xmlns='http://www.w3.org/2000/svg'
           elementFormDefault='qualified'>
  <xs:element name='svg' type='svgType'/>
  <xs:complexType name='svgType'>
    <xs:sequence>
      <xs:any minOccurs='0' maxOccurs='unbounded' processContents='lax'/>
    </xs:sequence>
    <xs:anyAttribute processContents='lax'/>
  </xs:complexType>
</xs:schema>";
                using (StringReader sr = new StringReader(svgSchema))
                {
                    schemas.Add("http://www.w3.org/2000/svg", XmlReader.Create(sr));
                }

                // Set up validation settings
                XmlReaderSettings settings = new XmlReaderSettings
                {
                    ValidationType = ValidationType.Schema,
                    Schemas = schemas,
                    DtdProcessing = DtdProcessing.Prohibit
                };

                List<string> validationErrors = new List<string>();
                settings.ValidationEventHandler += (sender, args) =>
                {
                    validationErrors.Add($"{args.Severity}: {args.Message}");
                };

                // Perform validation
                using (StringReader sr = new StringReader(svgContent))
                using (XmlReader reader = XmlReader.Create(sr, settings))
                {
                    while (reader.Read()) { /* reading triggers validation */ }
                }

                // Report results
                if (validationErrors.Count == 0)
                {
                    Console.WriteLine("SVG validation succeeded: the document conforms to the SVG schema.");
                }
                else
                {
                    Console.WriteLine("SVG validation failed with the following errors:");
                    foreach (string err in validationErrors)
                    {
                        Console.WriteLine(err);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}