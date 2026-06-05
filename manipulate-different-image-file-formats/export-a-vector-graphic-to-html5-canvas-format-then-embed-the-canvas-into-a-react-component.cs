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
            string inputPath = @"C:\Images\Sample.svg";
            string outputHtmlPath = @"C:\Images\Canvas.html";
            string reactComponentPath = @"C:\Images\CanvasComponent.jsx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputHtmlPath));
            Directory.CreateDirectory(Path.GetDirectoryName(reactComponentPath));

            // Load the vector image and export to HTML5 Canvas (canvas tag only)
            using (var image = Image.Load(inputPath))
            {
                var canvasOptions = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions(),
                    CanvasTagId = "myCanvas",
                    FullHtmlPage = false // export only the <canvas> tag
                };

                image.Save(outputHtmlPath, canvasOptions);
            }

            // Generate a simple React component that embeds the canvas
            string reactComponentContent = @"import React from 'react';

const CanvasComponent = () => (
    <canvas id=""myCanvas""></canvas>
);

export default CanvasComponent;
";

            File.WriteAllText(reactComponentPath, reactComponentContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer wants to convert an SVG logo into an HTML5 canvas element for faster rendering in a React single‑page application.
 * 2. When a SaaS platform needs to programmatically generate a reusable React component that displays vector graphics without loading external image files.
 * 3. When an e‑learning portal must embed scalable diagrams as canvas tags inside React components to support dynamic resizing and interactivity.
 * 4. When a marketing automation tool automates the transformation of SVG assets into React‑compatible canvas markup for email templates or landing pages.
 * 5. When a desktop .NET utility processes a batch of SVG files and creates corresponding React components that render the graphics on an HTML5 canvas for cross‑browser consistency.
 */