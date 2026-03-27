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
        // Hard‑coded source vector images, input HTML templates and output HTML files.
        string[] sourceImages = { "image1.svg", "image2.svg" };
        string[] inputHtmlFiles = { "template1.html", "template2.html" };
        string[] outputHtmlFiles = { "output1.html", "output2.html" };
        const string placeholder = "{{CANVAS_PLACEHOLDER}}";

        // Process each pair of source image and HTML file.
        for (int i = 0; i < sourceImages.Length && i < inputHtmlFiles.Length && i < outputHtmlFiles.Length; i++)
        {
            // Verify source image exists.
            if (!File.Exists(sourceImages[i]))
            {
                Console.Error.WriteLine($"File not found: {sourceImages[i]}");
                return;
            }

            // Verify input HTML file exists.
            if (!File.Exists(inputHtmlFiles[i]))
            {
                Console.Error.WriteLine($"File not found: {inputHtmlFiles[i]}");
                return;
            }

            // Generate only the <canvas> tag from the vector image.
            string canvasHtml;
            using (Image image = Image.Load(sourceImages[i]))
            {
                var options = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions(),
                    FullHtmlPage = false,               // Export only the canvas tag.
                    CanvasTagId = $"canvas{i}"           // Unique canvas identifier.
                };

                using (var ms = new MemoryStream())
                {
                    image.Save(ms, options);
                    canvasHtml = Encoding.UTF8.GetString(ms.ToArray());
                }
            }

            // Read the template HTML.
            string htmlContent = File.ReadAllText(inputHtmlFiles[i]);

            // Replace the placeholder token with the generated canvas HTML.
            string newContent = htmlContent.Replace(placeholder, canvasHtml);

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputHtmlFiles[i]));

            // Write the resulting HTML to the output file.
            File.WriteAllText(outputHtmlFiles[i], newContent);
        }
    }
}