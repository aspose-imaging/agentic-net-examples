using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input SVG files
            string[] svgInputs = {
                @"C:\Images\image1.svg",
                @"C:\Images\image2.svg"
            };

            // Corresponding HTML template files containing the placeholder token
            string[] htmlTemplates = {
                @"C:\Templates\page1.html",
                @"C:\Templates\page2.html"
            };

            // Desired output HTML files after embedding the canvas
            string[] htmlOutputs = {
                @"C:\Result\page1.html",
                @"C:\Result\page2.html"
            };

            // Placeholder token to be replaced with the generated canvas markup
            const string placeholderToken = "{{CANVAS_PLACEHOLDER}}";

            // Process each pair (SVG → HTML)
            for (int i = 0; i < svgInputs.Length; i++)
            {
                string svgPath = svgInputs[i];
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    continue;
                }

                // Temporary file that will hold only the canvas tag
                string tempCanvasPath = Path.Combine(Path.GetTempPath(), $"canvas_{i}.html");
                // Ensure the temp directory exists (it always does, but follow the rule)
                Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));

                // Generate the canvas HTML from the SVG source
                using (Image image = Image.Load(svgPath))
                {
                    var options = new Html5CanvasOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions(),
                        FullHtmlPage = false // Export only the <canvas> element
                    };
                    image.Save(tempCanvasPath, options);
                }

                // Read the generated canvas markup
                string canvasHtml = File.ReadAllText(tempCanvasPath);

                // Load the HTML template
                string templatePath = htmlTemplates[i];
                if (!File.Exists(templatePath))
                {
                    Console.Error.WriteLine($"File not found: {templatePath}");
                    continue;
                }

                string templateContent = File.ReadAllText(templatePath);

                // Replace the placeholder with the canvas markup
                string resultContent = templateContent.Replace(placeholderToken, canvasHtml);

                // Write the final HTML file
                string outputPath = htmlOutputs[i];
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                File.WriteAllText(outputPath, resultContent);

                // Clean up the temporary canvas file
                try { File.Delete(tempCanvasPath); } catch { /* ignore cleanup errors */ }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}