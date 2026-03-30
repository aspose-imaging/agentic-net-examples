using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;

class Program
{
    // Hardcoded input and output paths
    private const string InputPath = @"C:\temp\input.svg";
    private const string OutputPath = @"C:\temp\output.svg";

    static void Main()
    {
        // Verify input file exists
        if (!File.Exists(InputPath))
        {
            Console.Error.WriteLine($"File not found: {InputPath}");
            return;
        }

        // Read SVG content
        string svgContent = File.ReadAllText(InputPath, Encoding.UTF8);

        // Simple kernel processing: remove XML comments (example of filtering)
        svgContent = RemoveXmlComments(svgContent);

        // Validate the filtered SVG against the SVG 1.1 schema
        if (!ValidateSvg(svgContent))
        {
            Console.Error.WriteLine("SVG validation failed.");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));

        // Write the validated SVG to the output file
        File.WriteAllText(OutputPath, svgContent, Encoding.UTF8);
    }

    // Removes XML comments from the SVG string
    private static string RemoveXmlComments(string xml)
    {
        // Very simple comment removal using string replace (for demonstration)
        // In production, use proper XML parsing to handle comments.
        while (true)
        {
            int start = xml.IndexOf("<!--", StringComparison.Ordinal);
            if (start == -1) break;
            int end = xml.IndexOf("-->", start + 4, StringComparison.Ordinal);
            if (end == -1) break;
            xml = xml.Remove(start, (end + 3) - start);
        }
        return xml;
    }

    // Validates SVG content against an embedded SVG 1.1 schema
    private static bool ValidateSvg(string svgContent)
    {
        bool isValid = true;

        // Minimal SVG 1.1 schema (truncated for brevity). In a real scenario, use the full schema.
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

        // Prepare schema set
        XmlSchemaSet schemas = new XmlSchemaSet();
        using (StringReader sr = new StringReader(svgSchema))
        {
            schemas.Add("http://www.w3.org/2000/svg", XmlReader.Create(sr));
        }

        // Configure XML reader settings for validation
        XmlReaderSettings settings = new XmlReaderSettings
        {
            ValidationType = ValidationType.Schema,
            Schemas = schemas,
            DtdProcessing = DtdProcessing.Prohibit
        };
        settings.ValidationEventHandler += (sender, args) =>
        {
            // Any validation error marks the document as invalid
            isValid = false;
            Console.Error.WriteLine($"Validation {args.Severity}: {args.Message}");
        };

        // Perform validation
        using (StringReader stringReader = new StringReader(svgContent))
        using (XmlReader reader = XmlReader.Create(stringReader, settings))
        {
            try
            {
                while (reader.Read()) { }
            }
            catch (XmlException ex)
            {
                isValid = false;
                Console.Error.WriteLine($"XML parsing error: {ex.Message}");
            }
        }

        return isValid;
    }
}