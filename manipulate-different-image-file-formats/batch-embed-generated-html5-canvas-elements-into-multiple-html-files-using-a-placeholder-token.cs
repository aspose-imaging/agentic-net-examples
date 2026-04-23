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
        try
        {
            // Hard‑coded input vector images, HTML templates and output files
            string[] vectorPaths = { "input1.svg", "input2.svg" };
            string[] templatePaths = { "template1.html", "template2.html" };
            string[] outputPaths = { "output1.html", "output2.html" };
            const string placeholder = "{{CANVAS_PLACEHOLDER}}";

            for (int i = 0; i < vectorPaths.Length; i++)
            {
                string vectorPath = vectorPaths[i];
                string templatePath = templatePaths[i];
                string outputPath = outputPaths[i];

                // Verify input files exist
                if (!File.Exists(vectorPath))
                {
                    Console.Error.WriteLine($"File not found: {vectorPath}");
                    return;
                }
                if (!File.Exists(templatePath))
                {
                    Console.Error.WriteLine($"File not found: {templatePath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the vector image (e.g., SVG)
                using (Image image = Image.Load(vectorPath))
                {
                    // Prepare HTML5 Canvas options – generate only the canvas tag
                    var canvasOptions = new Html5CanvasOptions
                    {
                        FullHtmlPage = false,
                        CanvasTagId = $"canvas{i + 1}",
                        VectorRasterizationOptions = new SvgRasterizationOptions()
                    };

                    // Save canvas HTML to a memory stream
                    string canvasHtml;
                    using (var ms = new MemoryStream())
                    {
                        image.Save(ms, canvasOptions);
                        canvasHtml = Encoding.UTF8.GetString(ms.ToArray());
                    }

                    // Load the HTML template
                    string templateContent = File.ReadAllText(templatePath, Encoding.UTF8);

                    // Replace the placeholder token with the generated canvas HTML
                    string resultHtml = templateContent.Replace(placeholder, canvasHtml);

                    // Write the final HTML file
                    File.WriteAllText(outputPath, resultHtml, Encoding.UTF8);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}