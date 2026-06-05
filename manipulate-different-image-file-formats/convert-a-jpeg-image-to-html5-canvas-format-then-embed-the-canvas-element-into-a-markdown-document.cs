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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.jpg";
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

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as an HTML5 Canvas snippet (only the <canvas> tag)
                var canvasOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = false // export only the canvas element
                };
                image.Save(canvasPath, canvasOptions);
            }

            // Read the generated canvas HTML
            string canvasHtml = File.ReadAllText(canvasPath);

            // Build markdown content embedding the canvas HTML
            string markdownContent = "# Image Canvas\n\n```html\n" + canvasHtml + "\n```\n";

            // Write the markdown file
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
 * 1. When a developer wants to display a JPEG image in a static site generator that renders Markdown, they can convert the image to an HTML5 canvas snippet and embed it directly in the Markdown file.
 * 2. When creating technical documentation that requires interactive image rendering without external image files, this code lets you embed the JPEG as a canvas element inside the Markdown, ensuring the document is self‑contained.
 * 3. When building a blog post that uses Markdown and needs to avoid mixed content warnings, converting the JPEG to a canvas and inserting it into the Markdown guarantees the image is rendered via HTML5 canvas rather than a separate image URL.
 * 4. When generating automated reports in C# where images must be displayed in environments that only support HTML fragments inside Markdown, the code transforms the JPEG into a canvas tag and inserts it into the report’s Markdown section.
 * 5. When preparing e‑learning material that combines Markdown lessons with visual examples, developers can use this code to embed JPEG graphics as HTML5 canvas elements, allowing the content to be viewed consistently across browsers without loading external image files.
 */