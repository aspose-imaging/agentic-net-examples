// HOW-TO: Convert OTG to Minified SVG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.otg";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
                string tempPath = outputPath + ".tmp";

                image.Save(tempPath, options);

                string svgContent = File.ReadAllText(tempPath);
                var xmlDoc = new XmlDocument { PreserveWhitespace = false };
                xmlDoc.LoadXml(svgContent);

                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = false,
                    Indent = false,
                    NewLineHandling = NewLineHandling.None,
                    Encoding = new UTF8Encoding(false)
                };

                using (var writer = XmlWriter.Create(outputPath, settings))
                {
                    xmlDoc.Save(writer);
                }

                File.Delete(tempPath);
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
 * 1. When you need to embed vector graphics from an OTG design into a web page and want the smallest possible SVG file size.
 * 2. When a build pipeline must automatically transform OTG assets into SVG format using Aspose.Imaging in C# while removing unnecessary whitespace.
 * 3. When a desktop application processes user‑uploaded OTG files and stores them as compact SVG files for faster loading and lower storage costs.
 * 4. When you are migrating legacy OTG illustrations to a modern SVG‑based reporting system and require clean, minified XML without indentation.
 * 5. When a CI/CD script generates SVG previews from OTG sources and needs the output to be minified for efficient version‑control diffs.
 */
