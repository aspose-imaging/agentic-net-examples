using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string canvasOutputPath = "canvas.html";
        string finalHtmlPath = "output.html";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(canvasOutputPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(finalHtmlPath) ?? string.Empty);

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Save only the canvas tag (no full HTML page)
                var canvasOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = false,
                    // Optional: set a canvas tag identifier
                    CanvasTagId = "myCanvas"
                };
                image.Save(canvasOutputPath, canvasOptions);
            }

            // Read the generated canvas snippet
            string canvasSnippet = File.ReadAllText(canvasOutputPath);

            // Build a full HTML page that embeds the canvas
            string fullHtml = $"<!DOCTYPE html>{Environment.NewLine}" +
                              $"<html>{Environment.NewLine}" +
                              $"<head>{Environment.NewLine}" +
                              $"    <meta charset=\"UTF-8\" />{Environment.NewLine}" +
                              $"    <title>Canvas Export</title>{Environment.NewLine}" +
                              $"</head>{Environment.NewLine}" +
                              $"<body>{Environment.NewLine}" +
                              $"    {canvasSnippet}{Environment.NewLine}" +
                              $"</body>{Environment.NewLine}" +
                              $"</html>";

            // Write the final HTML page
            File.WriteAllText(finalHtmlPath, fullHtml);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer wants to display a PNG logo on a dynamic HTML5 page without using external image files, they can convert the raster image to a canvas element with Aspose.Imaging and embed it directly in the page.
 * 2. When building an email template that must inline images for better compatibility, a developer can export the image to a canvas snippet and insert it into the HTML body to avoid attachment handling.
 * 3. When creating an interactive reporting dashboard that draws charts on a canvas, a programmer can pre‑render static background graphics as a canvas tag using the Html5CanvasOptions and merge it into the final HTML layout.
 * 4. When generating printable web‑ready documentation where images need to be part of the HTML source for offline viewing, the code can transform each source PNG into an embedded canvas element.
 * 5. When developing a single‑page application that loads assets on the fly, a developer can use this approach to convert server‑side raster assets to canvas markup, reducing HTTP requests and simplifying client‑side rendering.
 */