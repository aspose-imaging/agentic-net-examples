using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputImagePath = @"input.svg";
        string templatePath = @"template.html";
        string outputPath = @"output.html";
        string tempCanvasPath = @"canvas_temp.html";

        try
        {
            // Verify input image exists
            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }

            // Verify template exists
            if (!File.Exists(templatePath))
            {
                Console.Error.WriteLine($"File not found: {templatePath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));

            // Load the source vector image
            using (Image image = Image.Load(inputImagePath))
            {
                // Export only the canvas tag (no full HTML page)
                var canvasOptions = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions(),
                    FullHtmlPage = false
                };

                // Save canvas HTML to a temporary file
                image.Save(tempCanvasPath, canvasOptions);
            }

            // Read generated canvas HTML
            string canvasHtml = File.ReadAllText(tempCanvasPath);

            // Read the existing HTML template
            string templateHtml = File.ReadAllText(templatePath);

            // Placeholder in the template where the canvas should be inserted
            const string placeholder = "{{CANVAS}}";

            // Replace placeholder with the canvas HTML
            string finalHtml = templateHtml.Replace(placeholder, canvasHtml);

            // Write the final HTML to the output file
            File.WriteAllText(outputPath, finalHtml);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert an SVG illustration into an HTML5 canvas script and insert it into a custom HTML email template for consistent rendering across email clients.
 * 2. When a web application must display vector graphics on a responsive page by generating a canvas element from a source SVG and embedding it into a pre‑designed HTML layout at runtime.
 * 3. When an e‑learning platform wants to programmatically replace a placeholder in a lesson HTML page with a canvas‑based rendering of a diagram stored as an SVG file using C# and Aspose.Imaging.
 * 4. When a reporting tool generates PDF‑like dashboards and requires the vector chart to be exported as a canvas snippet that can be merged into an existing HTML report template.
 * 5. When a content management system automates the publishing workflow by converting uploaded SVG assets into canvas code and injecting them into a static HTML page template before publishing.
 */