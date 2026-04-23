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
        string canvasSnippetPath = @"CanvasSnippet.html";
        string templatePath = @"Template.html";
        string resultPath = @"Result.html";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(canvasSnippetPath));
        Directory.CreateDirectory(Path.GetDirectoryName(resultPath));

        try
        {
            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Export only the canvas tag (no full HTML page)
                var options = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions(),
                    FullHtmlPage = false
                };

                // Save canvas snippet
                image.Save(canvasSnippetPath, options);
            }

            // Read generated canvas HTML
            string canvasHtml = File.ReadAllText(canvasSnippetPath);

            // Read the existing HTML template
            string templateHtml = File.ReadAllText(templatePath);

            // Embed the canvas HTML into the template (placeholder {{CANVAS}})
            string finalHtml = templateHtml.Replace("{{CANVAS}}", canvasHtml);

            // Write the final HTML file
            File.WriteAllText(resultPath, finalHtml);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}