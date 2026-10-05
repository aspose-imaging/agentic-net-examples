// HOW-TO: Convert ODG to SVG and Strip Group Tags in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
                image.Save(outputPath, options);
            }

            string svgContent = File.ReadAllText(outputPath);
            string simplified = Regex.Replace(svgContent, @"</?g[^>]*>", "", RegexOptions.Singleline);
            File.WriteAllText(outputPath, simplified);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed an OpenDocument Graphic (ODG) into a web page, you can convert it to SVG and remove unnecessary <g> elements to keep the markup lightweight.
 * 2. When automating a batch process that prepares vector assets for mobile apps, this code converts ODG files to SVG and simplifies the SVG by stripping group tags, reducing file size.
 * 3. When integrating Aspose.Imaging in a C# service that receives user‑uploaded ODG drawings, you can output clean SVG without extra grouping for downstream editing tools.
 * 4. When optimizing SVGs for faster rendering in browsers, the code transforms ODG to SVG and eliminates redundant group elements using a regular expression.
 * 5. When creating a CI pipeline that validates and normalizes vector graphics, this snippet converts ODG to SVG and cleans the markup, ensuring consistent SVG structure across builds.
 */
