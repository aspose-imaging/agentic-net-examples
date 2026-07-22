using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\sample.svg";
        string canvasOutputPath = @"C:\Images\canvas.html";
        string reactComponentPath = @"C:\Images\CanvasComponent.jsx";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(canvasOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(reactComponentPath));

            // Load the vector image and export only the canvas tag
            using (Image image = Image.Load(inputPath))
            {
                var htmlOptions = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions(),
                    FullHtmlPage = false // export only the <canvas> tag
                };
                image.Save(canvasOutputPath, htmlOptions);
            }

            // Read the generated canvas HTML
            string canvasHtml = File.ReadAllText(canvasOutputPath);

            // Escape backticks for embedding in a template literal
            string escapedCanvasHtml = canvasHtml.Replace("`", "\\`");

            // Build a simple React component that injects the canvas HTML
            string reactComponentCode = $@"import React from 'react';

const CanvasComponent = () => (
  <div dangerouslySetInnerHTML={{ __html: `{escapedCanvasHtml}` }} />
);

export default CanvasComponent;
";

            // Write the React component file
            File.WriteAllText(reactComponentPath, reactComponentCode);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to display a scalable SVG logo inside a React web application without loading external files, they can export the SVG to an HTML5 canvas tag and embed it as a React component.
 * 2. When building an interactive data‑visualization dashboard, a developer can convert complex SVG charts to canvas HTML and inject them into React components for faster rendering on low‑power devices.
 * 3. When migrating a legacy desktop reporting tool to a modern SPA, a developer can use this code to transform SVG diagrams into canvas elements that can be safely rendered with React’s dangerouslySetInnerHTML.
 * 4. When creating a reusable UI library of vector icons, a developer can generate canvas‑based React components from SVG assets to ensure consistent pixel‑perfect rendering across browsers.
 * 5. When generating dynamic marketing emails that include vector graphics, a developer can export the SVG to a canvas snippet and embed it in a React component that later renders the HTML email content.
 */