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
            string[] svgInputs = {
                @"C:\Images\Input1.svg",
                @"C:\Images\Input2.svg"
            };

            // Hard‑coded HTML template files containing the placeholder {{CANVAS_PLACEHOLDER}}
            string[] htmlTemplates = {
                @"C:\Html\Template1.html",
                @"C:\Html\Template2.html"
            };

            // Output HTML files (same name as template with suffix "_out")
            string[] htmlOutputs = {
                @"C:\Html\Result1_out.html",
                @"C:\Html\Result2_out.html"
            };

            const string placeholder = "{{CANVAS_PLACEHOLDER}}";

            // Validate existence of all SVG inputs
            foreach (var svgPath in svgInputs)
            {
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    return;
                }
            }

            // Validate existence of all HTML template inputs
            foreach (var tmplPath in htmlTemplates)
            {
                if (!File.Exists(tmplPath))
                {
                    Console.Error.WriteLine($"File not found: {tmplPath}");
                    return;
                }
            }

            // Process each pair (SVG -> HTML)
            for (int i = 0; i < svgInputs.Length && i < htmlTemplates.Length && i < htmlOutputs.Length; i++)
            {
                string svgPath = svgInputs[i];
                string templatePath = htmlTemplates[i];
                string outputPath = htmlOutputs[i];

                // Load SVG image
                using (Image image = Image.Load(svgPath))
                {
                    // Render SVG to HTML5 canvas fragment (no full page)
                    using (var ms = new MemoryStream())
                    {
                        var options = new Html5CanvasOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions(),
                            FullHtmlPage = false,
                            CanvasTagId = $"canvas{i}"
                        };
                        image.Save(ms, options);
                        string canvasHtml = Encoding.UTF8.GetString(ms.ToArray());

                        // Read template, replace placeholder
                        string templateContent = File.ReadAllText(templatePath);
                        string resultContent = templateContent.Replace(placeholder, canvasHtml);

                        // Ensure output directory exists
                        string outputDir = Path.GetDirectoryName(outputPath);
                        Directory.CreateDirectory(outputDir ?? ".");

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
 * 1. When a developer needs to automatically replace a {{CANVAS_PLACEHOLDER}} token in multiple HTML templates with rendered SVG graphics as HTML5 canvas elements for a product catalog.
 * 2. When a web application must batch‑process SVG files into canvas fragments and embed them into pre‑designed HTML pages using Aspose.Imaging for dynamic report generation.
 * 3. When an e‑learning platform wants to convert a set of SVG diagrams into interactive canvas snippets and insert them into course HTML modules without manual editing.
 * 4. When a marketing team requires a C# script that reads SVG logos, renders them to HTML5 canvas code, and updates several landing‑page HTML files containing the placeholder token.
 * 5. When a CI/CD pipeline needs to validate that all SVG assets are correctly rendered into canvas HTML and embedded into the corresponding documentation HTML files during build time.
 */