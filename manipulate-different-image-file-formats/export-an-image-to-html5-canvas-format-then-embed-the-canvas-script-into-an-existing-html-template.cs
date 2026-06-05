using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"Sample.svg";
        string canvasPath = @"Canvas.html";
        string templatePath = @"Template.html";
        string resultPath = @"Result.html";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Template file existence check
        if (!File.Exists(templatePath))
        {
            Console.Error.WriteLine($"File not found: {templatePath}");
            return;
        }

        try
        {
            // Load the source image
            using (var image = Image.Load(inputPath))
            {
                // Prepare HTML5 Canvas export options (export only the canvas tag)
                var options = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions(),
                    FullHtmlPage = false
                };

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));

                // Save the canvas HTML fragment
                image.Save(canvasPath, options);
            }

            // Read the generated canvas fragment
            string canvasHtml = File.ReadAllText(canvasPath);

            // Read the existing HTML template
            string templateHtml = File.ReadAllText(templatePath);

            // Replace placeholder {{CANVAS}} with the canvas fragment
            string resultHtml = templateHtml.Replace("{{CANVAS}}", canvasHtml);

            // Ensure result directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(resultPath));

            // Write the final HTML file
            File.WriteAllText(resultPath, resultHtml);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to convert an SVG illustration into an HTML5 canvas snippet using C# and Aspose.Imaging so it can be embedded directly into a web page without loading the original SVG file.
 * 2. When a web application needs to generate a server‑side canvas preview of a vector graphic and insert it into an existing HTML template for faster client rendering.
 * 3. When an e‑learning platform must dynamically insert a rasterized SVG canvas into a pre‑designed HTML template to create interactive lesson content.
 * 4. When a reporting tool has to merge a canvas‑based rendering of an SVG image with static HTML layout elements such as headers, footers, and navigation menus.
 * 5. When a CI/CD pipeline automates the transformation of SVG assets into HTML5 canvas fragments and combines them with HTML templates for automated deployment.
 */