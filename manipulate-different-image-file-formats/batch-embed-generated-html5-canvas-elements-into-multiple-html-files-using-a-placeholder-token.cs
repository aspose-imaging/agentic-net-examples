using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input vector images (SVG, WMF, etc.)
            string[] vectorImagePaths = {
                @"InputImages\Image1.svg",
                @"InputImages\Image2.svg"
            };

            // Hard‑coded HTML template files containing the placeholder token
            string[] htmlTemplatePaths = {
                @"Templates\Page1.html",
                @"Templates\Page2.html"
            };

            // Corresponding output HTML files
            string[] outputHtmlPaths = {
                @"Output\Page1.html",
                @"Output\Page2.html"
            };

            // Placeholder token that will be replaced by generated canvas markup
            const string placeholderToken = "{{CANVAS_PLACEHOLDER}}";

            // Validate existence of all vector image inputs
            foreach (var vecPath in vectorImagePaths)
            {
                if (!File.Exists(vecPath))
                {
                    Console.Error.WriteLine($"File not found: {vecPath}");
                    return;
                }
            }

            // Validate existence of all HTML template inputs
            foreach (var tmplPath in htmlTemplatePaths)
            {
                if (!File.Exists(tmplPath))
                {
                    Console.Error.WriteLine($"File not found: {tmplPath}");
                    return;
                }
            }

            // Generate canvas fragments (only the <canvas> tag, not a full HTML page)
            List<string> canvasFragments = new List<string>();
            foreach (var vecPath in vectorImagePaths)
            {
                using (Image image = Image.Load(vecPath))
                {
                    var options = new Html5CanvasOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions(),
                        FullHtmlPage = false,
                        Encoding = System.Text.Encoding.UTF8
                    };

                    using (var ms = new MemoryStream())
                    {
                        image.Save(ms, options);
                        ms.Position = 0;
                        using (var reader = new StreamReader(ms))
                        {
                            string canvasHtml = reader.ReadToEnd();
                            canvasFragments.Add(canvasHtml);
                        }
                    }
                }
            }

            // Combine all canvas fragments into a single string (separated by new lines)
            string combinedCanvasHtml = string.Join(Environment.NewLine, canvasFragments);

            // Process each HTML template, replace the placeholder, and write the result
            for (int i = 0; i < htmlTemplatePaths.Length; i++)
            {
                string templatePath = htmlTemplatePaths[i];
                string outputPath = outputHtmlPaths[i];

                string templateContent = File.ReadAllText(templatePath);
                string resultContent = templateContent.Replace(placeholderToken, combinedCanvasHtml);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                File.WriteAllText(outputPath, resultContent);
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
 * 1. When a developer needs to convert a set of SVG or WMF vector graphics into interactive HTML5 canvas elements and insert them into several product documentation pages that contain a {{CANVAS_PLACEHOLDER}} token.
 * 2. When an e‑learning platform wants to automatically embed scalable illustrations as canvas markup into multiple lesson HTML templates without manually editing each file.
 * 3. When a reporting tool generates charts as vector images and must batch‑replace placeholders in pre‑designed HTML report templates with canvas fragments for responsive web viewing.
 * 4. When a marketing team maintains a library of promotional banners stored as SVG files and wants a C# script to embed them as HTML5 canvas tags into dozens of landing‑page HTML files using a placeholder token.
 * 5. When a SaaS dashboard needs to programmatically update its UI by converting updated vector icons into canvas elements and injecting them into several HTML widget templates during a build process.
 */