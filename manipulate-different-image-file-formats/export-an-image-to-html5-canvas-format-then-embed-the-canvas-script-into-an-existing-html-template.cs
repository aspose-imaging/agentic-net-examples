using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"Sample.svg";
        string templatePath = @"template.html";
        string outputPath = @"Result.html";

        try
        {
            // Verify input image exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Verify HTML template exists
            if (!File.Exists(templatePath))
            {
                Console.Error.WriteLine($"File not found: {templatePath}");
                return;
            }

            // Read template content
            string templateContent = File.ReadAllText(templatePath);

            // Export image to HTML5 Canvas (only the canvas tag)
            string canvasHtml;
            using (Image image = Image.Load(inputPath))
            {
                using (var ms = new MemoryStream())
                {
                    var options = new Html5CanvasOptions
                    {
                        FullHtmlPage = false, // generate only the canvas tag
                        VectorRasterizationOptions = new SvgRasterizationOptions()
                    };
                    image.Save(ms, options);
                    canvasHtml = Encoding.UTF8.GetString(ms.ToArray());
                }
            }

            // Embed canvas HTML into the template (replace placeholder {{CANVAS}})
            string resultHtml = templateContent.Replace("{{CANVAS}}", canvasHtml);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Write the final HTML file
            File.WriteAllText(outputPath, resultHtml, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to convert an SVG illustration into an HTML5 canvas element and embed it into a custom web page template for dynamic rendering in browsers.
 * 2. When a C# application needs to generate a lightweight HTML snippet from a vector image (SVG) without the surrounding HTML boilerplate, to insert into an existing HTML email or dashboard.
 * 3. When a software solution must programmatically replace a placeholder in an HTML template with a rasterized canvas representation of a logo stored as SVG, ensuring consistent branding across web pages.
 * 4. When an ASP.NET project requires on‑the‑fly conversion of user‑uploaded SVG files to canvas code that can be saved as a single HTML file using Aspose.Imaging’s Html5CanvasOptions.
 * 5. When a developer is building a reporting tool that merges chart images (SVG) into pre‑designed HTML report templates by exporting the charts to canvas tags and writing the final HTML output.
 */