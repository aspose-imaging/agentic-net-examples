using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputHtmlPath = "output.html";
            string reactComponentPath = "CanvasComponent.jsx";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputHtmlPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(reactComponentPath) ?? string.Empty);

            // Load the vector image and export to HTML5 Canvas
            using (Image image = Image.Load(inputPath))
            {
                Html5CanvasOptions canvasOptions = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions(),
                    CanvasTagId = "myCanvas",
                    FullHtmlPage = false
                };
                image.Save(outputHtmlPath, canvasOptions);
            }

            // Create a simple React component that embeds the canvas tag
            string componentContent = 
@"import React from 'react';

const CanvasComponent = () => (
  <canvas id=""myCanvas""></canvas>
);

export default CanvasComponent;
";

            File.WriteAllText(reactComponentPath, componentContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to convert an SVG logo into an HTML5 Canvas element for dynamic rendering in a web page built with React.
 * 2. When a team needs to automate the generation of reusable React components that embed vector graphics without relying on external image files.
 * 3. When a .NET backend service must export vector illustrations to lightweight canvas markup to improve page load performance in single‑page applications.
 * 4. When a designer wants to preview SVG artwork directly inside a React component during development, using Aspose.Imaging to handle the SVG‑to‑Canvas conversion.
 * 5. When an e‑learning platform requires programmatic conversion of SVG diagrams to HTML5 Canvas so they can be manipulated with JavaScript in a React‑based interactive tutorial.
 */