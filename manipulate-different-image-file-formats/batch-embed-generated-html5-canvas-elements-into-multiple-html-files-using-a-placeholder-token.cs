// HOW-TO: Batch Replace Placeholder With HTML5 Canvas From SVG Files Using C# (Aspose.Imaging for .NET)
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
            // Hard‑coded source SVG files
            string[] svgSources = {
                @"C:\Input\Sample1.svg",
                @"C:\Input\Sample2.svg"
            };

            // Corresponding HTML files that contain the placeholder token {{CANVAS_PLACEHOLDER}}
            string[] htmlTemplates = {
                @"C:\Input\Page1.html",
                @"C:\Input\Page2.html"
            };

            // Output HTML files
            string[] htmlOutputs = {
                @"C:\Output\Page1.html",
                @"C:\Output\Page2.html"
            };

            const string placeholder = "{{CANVAS_PLACEHOLDER}}";

            // Ensure the arrays have matching lengths
            if (svgSources.Length != htmlTemplates.Length || svgSources.Length != htmlOutputs.Length)
            {
                Console.Error.WriteLine("Configuration error: source, template, and output arrays must have the same length.");
                return;
            }

            for (int i = 0; i < svgSources.Length; i++)
            {
                string svgPath = svgSources[i];
                string templatePath = htmlTemplates[i];
                string outputPath = htmlOutputs[i];

                // Input validation for SVG source
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    return;
                }

                // Input validation for HTML template
                if (!File.Exists(templatePath))
                {
                    Console.Error.WriteLine($"File not found: {templatePath}");
                    return;
                }

                // Load SVG and generate canvas HTML fragment (no full page)
                string canvasHtml;
                using (Image image = Image.Load(svgPath))
                {
                    using (var ms = new MemoryStream())
                    {
                        var options = new Html5CanvasOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions(),
                            FullHtmlPage = false,
                            CanvasTagId = $"canvas{i}"
                        };
                        image.Save(ms, options);
                        canvasHtml = Encoding.UTF8.GetString(ms.ToArray());
                    }
                }

                // Read template, replace placeholder with generated canvas HTML
                string templateContent = File.ReadAllText(templatePath);
                string resultContent = templateContent.Replace(placeholder, canvasHtml);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Write the resulting HTML file
                File.WriteAllText(outputPath, resultContent, Encoding.UTF8);
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
 * 1. When you need to automatically insert SVG‑derived canvas graphics into a series of web pages during a build process.
 * 2. When generating product documentation where each HTML file must display a dynamic canvas rendering of a corresponding SVG diagram.
 * 3. When creating an e‑learning portal that swaps a placeholder token with interactive canvas elements for multiple lessons in one batch.
 * 4. When migrating legacy HTML templates that contain {{CANVAS_PLACEHOLDER}} to modern HTML5 canvas content without manual editing.
 * 5. When automating the preparation of marketing landing pages that require SVG images to be rendered as canvas snippets across many files.
 */
