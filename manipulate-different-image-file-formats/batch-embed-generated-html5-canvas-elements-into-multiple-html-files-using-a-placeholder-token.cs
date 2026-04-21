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
        // Hard‑coded input SVG files
        string[] svgInputPaths = {
            @"C:\Images\Sample1.svg",
            @"C:\Images\Sample2.svg"
        };

        // Corresponding HTML template files containing the placeholder {{CANVAS_PLACEHOLDER}}
        string[] htmlTemplatePaths = {
            @"C:\Templates\Page1.html",
            @"C:\Templates\Page2.html"
        };

        // Output HTML files where the canvas will be embedded
        string[] htmlOutputPaths = {
            @"C:\Output\Result1.html",
            @"C:\Output\Result2.html"
        };

        // Placeholder token to be replaced with the generated canvas tag
        const string placeholderToken = "{{CANVAS_PLACEHOLDER}}";

        // Process each pair (SVG → HTML template → output)
        for (int i = 0; i < svgInputPaths.Length; i++)
        {
            string svgPath = svgInputPaths[i];
            string templatePath = htmlTemplatePaths[i];
            string outputPath = htmlOutputPaths[i];

            // Verify SVG input file exists
            if (!File.Exists(svgPath))
            {
                Console.Error.WriteLine($"File not found: {svgPath}");
                return;
            }

            // Verify HTML template file exists
            if (!File.Exists(templatePath))
            {
                Console.Error.WriteLine($"File not found: {templatePath}");
                return;
            }

            // Load the SVG image
            using (Image image = Image.Load(svgPath))
            {
                // Prepare options to generate only the canvas tag (no full HTML page)
                var canvasOptions = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions(),
                    FullHtmlPage = false,
                    CanvasTagId = $"canvas_{i}"
                };

                // Save the canvas HTML to a memory stream
                string canvasHtml;
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, canvasOptions);
                    canvasHtml = Encoding.UTF8.GetString(ms.ToArray());
                }

                // Read the HTML template
                string templateContent = File.ReadAllText(templatePath);

                // Replace the placeholder with the generated canvas HTML
                string resultContent = templateContent.Replace(placeholderToken, canvasHtml);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Write the final HTML file
                File.WriteAllText(outputPath, resultContent);
            }
        }
    }
}