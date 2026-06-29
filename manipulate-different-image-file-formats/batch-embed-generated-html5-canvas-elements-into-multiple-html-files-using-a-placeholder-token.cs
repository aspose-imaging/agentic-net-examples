using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input SVG files
            string[] svgInputs = new[]
            {
                "Sample1.svg",
                "Sample2.svg"
            };

            // Hard‑coded HTML template files containing the placeholder {{CANVAS}}
            string[] htmlTemplates = new[]
            {
                "Template1.html",
                "Template2.html"
            };

            const string placeholder = "{{CANVAS}}";

            // Process each SVG image
            foreach (string svgPath in svgInputs)
            {
                // Verify SVG input exists
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    return;
                }

                // Load the vector image
                using (Image image = Image.Load(svgPath))
                {
                    // Prepare options to generate only the canvas tag
                    var canvasOptions = new Html5CanvasOptions
                    {
                        FullHtmlPage = false,
                        CanvasTagId = "canvas_" + Path.GetFileNameWithoutExtension(svgPath),
                        Encoding = Encoding.UTF8
                    };

                    // Export canvas HTML to a memory stream
                    string canvasHtml;
                    using (var ms = new MemoryStream())
                    {
                        image.Save(ms, canvasOptions);
                        ms.Position = 0;
                        using (var reader = new StreamReader(ms, canvasOptions.Encoding))
                        {
                            canvasHtml = reader.ReadToEnd();
                        }
                    }

                    // Embed the canvas HTML into each template
                    foreach (string templatePath in htmlTemplates)
                    {
                        // Verify template input exists
                        if (!File.Exists(templatePath))
                        {
                            Console.Error.WriteLine($"File not found: {templatePath}");
                            return;
                        }

                        // Read the template content
                        string templateContent = File.ReadAllText(templatePath, Encoding.UTF8);

                        // Replace the placeholder with the generated canvas HTML
                        string resultContent = templateContent.Replace(placeholder, canvasHtml);

                        // Determine output file path
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(templatePath)}_{Path.GetFileNameWithoutExtension(svgPath)}.html";
                        string outputPath = Path.Combine("output", outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Write the final HTML file
                        File.WriteAllText(outputPath, resultContent, Encoding.UTF8);
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automatically convert a collection of SVG icons into HTML5 Canvas tags and insert them into several HTML email templates that contain a {{CANVAS}} placeholder.
 * 2. When a web application must generate responsive product‑detail pages by rendering vector graphics from SVG files as canvas elements and embedding them into multiple HTML layout files during a build step.
 * 3. When an e‑learning platform wants to batch replace placeholder tokens in course HTML pages with interactive canvas drawings generated from SVG diagrams using Aspose.Imaging for .NET.
 * 4. When a marketing team requires a C# script to produce lightweight canvas‑based graphics from SVG logos and embed them into a set of landing‑page HTML files without manually editing each file.
 * 5. When a developer automates the creation of printable reports that include vector illustrations rendered as HTML5 Canvas, inserting the generated canvas markup into several pre‑designed HTML report templates.
 */