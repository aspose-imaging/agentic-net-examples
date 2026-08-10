// HOW-TO: Export SVG to HTML5 Canvas and Embed in Template C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"input.svg";
        string templatePath = @"template.html";
        string outputPath = @"output.html";

        try
        {
            // Verify input image exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Verify template exists
            if (!File.Exists(templatePath))
            {
                Console.Error.WriteLine($"File not found: {templatePath}");
                return;
            }

            // Load the source image
            using (var image = Image.Load(inputPath))
            {
                // Prepare HTML5 Canvas export options (only canvas tag, no full page)
                var options = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions(),
                    FullHtmlPage = false
                };

                // Export canvas HTML to a memory stream
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, options);
                    ms.Position = 0;
                    string canvasHtml = Encoding.UTF8.GetString(ms.ToArray());

                    // Read the HTML template
                    string templateContent = File.ReadAllText(templatePath, Encoding.UTF8);

                    // Insert the canvas HTML into the template (placeholder {{CANVAS}})
                    string finalHtml = templateContent.Replace("{{CANVAS}}", canvasHtml);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Write the final HTML to the output file
                    File.WriteAllText(outputPath, finalHtml, Encoding.UTF8);
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
 * 1. When you need to display a scalable vector graphic on a web page using an HTML5 canvas without loading the original SVG file.
 * 2. When you want to integrate a generated canvas script into an existing HTML layout that contains placeholders for dynamic content.
 * 3. When you must programmatically convert SVG assets to client‑side canvas code as part of an automated build or reporting pipeline.
 * 4. When you are creating a single‑page application that loads images from a server‑side .NET service and injects them into the DOM at runtime.
 * 5. When you need to ensure the output HTML file is saved in a specific folder structure while preserving UTF‑8 encoding for international characters.
 */
