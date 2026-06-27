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
            // Hardcoded paths
            string inputPath = @"C:\temp\sample.jpg";
            string canvasPath = @"C:\temp\output\canvas.html";
            string markdownPath = @"C:\temp\output\image.md";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));
            Directory.CreateDirectory(Path.GetDirectoryName(markdownPath));

            // Load JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Save as HTML5 Canvas (only the canvas tag)
                var canvasOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = false
                };
                image.Save(canvasPath, canvasOptions);
            }

            // Read the generated canvas tag
            string canvasTag = File.ReadAllText(canvasPath);

            // Create markdown content embedding the canvas
            string markdownContent = $"# Image Canvas{Environment.NewLine}{Environment.NewLine}{canvasTag}{Environment.NewLine}";

            // Write markdown file
            File.WriteAllText(markdownPath, markdownContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to create a self‑contained Markdown document that displays a JPEG image without relying on external image files, they can convert the JPEG to an HTML5 canvas tag and embed it directly.
 * 2. When building a static site generator that outputs Markdown, this code allows the conversion of source JPEG assets into canvas elements so the images render consistently in browsers supporting HTML5 canvas.
 * 3. When automating report generation that embeds JPEG charts into Markdown files, converting the JPEG to a canvas tag prevents broken image links in environments that strip external resources.
 * 4. When a Markdown previewer only supports HTML5 canvas for image rendering, a developer can use this snippet to transform a JPEG into a canvas element and insert it into the Markdown content.
 * 5. When preparing e‑learning material where Markdown is exported to PDF and the exporter only renders canvas elements, this code enables embedding JPEG illustrations as HTML5 canvas for accurate visual representation.
 */