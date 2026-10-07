// HOW-TO: Convert BMP to SVG and Add Custom CSS with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = { "input1.bmp", "input2.bmp" };
            string[] outputPaths = { "output1.svg", "output2.svg" };
            string cssContent = "svg { background-color: #f0f0f0; }";

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Load BMP and convert to SVG
                using (Image image = Image.Load(inputPath))
                {
                    var svgOptions = new SvgOptions();
                    image.Save(outputPath, svgOptions);
                }

                // Embed custom CSS stylesheet into the SVG
                XDocument svgDoc = XDocument.Load(outputPath);
                XNamespace ns = "http://www.w3.org/2000/svg";
                XElement styleElement = new XElement(ns + "style",
                    new XAttribute("type", "text/css"),
                    new XCData(cssContent));
                svgDoc.Root.AddFirst(styleElement);
                svgDoc.Save(outputPath);
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
 * 1. When you need to batch‑convert legacy BMP graphics to scalable SVG files while applying a consistent visual style through an embedded CSS stylesheet.
 * 2. When a web application must serve vector images generated from BMP assets and requires the SVGs to include custom background or color rules without external CSS files.
 * 3. When automating the preparation of design assets for responsive websites, you can transform multiple BMP icons into SVGs and inject brand‑specific CSS directly into each file.
 * 4. When integrating image processing into a C# build pipeline, this code lets you convert BMP resources to SVG and embed styling so downstream tools can render them correctly.
 * 5. When creating printable or interactive diagrams from BMP sources, embedding CSS ensures the SVGs retain desired styling when opened in browsers or vector editors.
 */
