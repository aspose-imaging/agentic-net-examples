using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputImagePath = "input.svg";
        string templatePath = "template.html";
        string canvasTempPath = "canvas.html";
        string finalOutputPath = "output.html";

        try
        {
            // Validate input image
            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }

            // Validate HTML template
            if (!File.Exists(templatePath))
            {
                Console.Error.WriteLine($"File not found: {templatePath}");
                return;
            }

            // Ensure directories for temporary and final outputs exist
            Directory.CreateDirectory(Path.GetDirectoryName(canvasTempPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(finalOutputPath) ?? string.Empty);

            // Load the source image (e.g., SVG)
            using (var image = Image.Load(inputImagePath))
            {
                // Export only the canvas tag (no full HTML page)
                var options = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions(),
                    FullHtmlPage = false
                };
                image.Save(canvasTempPath, options);
            }

            // Read generated canvas HTML
            string canvasHtml = File.ReadAllText(canvasTempPath);

            // Read the existing HTML template
            string templateHtml = File.ReadAllText(templatePath);

            // Embed the canvas HTML into the template (replace placeholder {{CANVAS}})
            string finalHtml = templateHtml.Replace("{{CANVAS}}", canvasHtml);

            // Write the final HTML file
            File.WriteAllText(finalOutputPath, finalHtml);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}