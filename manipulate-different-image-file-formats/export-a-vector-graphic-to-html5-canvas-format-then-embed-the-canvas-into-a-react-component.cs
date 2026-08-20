// HOW-TO: Export SVG to HTML5 Canvas and Generate React Component in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.html";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the vector image (e.g., SVG)
            using (Image image = Image.Load(inputPath))
            {
                // Configure HTML5 Canvas export options
                var canvasOptions = new Html5CanvasOptions
                {
                    // Rasterize the vector source
                    VectorRasterizationOptions = new SvgRasterizationOptions(),
                    // Export only the canvas tag (no full HTML page)
                    FullHtmlPage = false
                };

                // Save the canvas HTML file
                image.Save(outputPath, canvasOptions);
            }

            // Generate a simple React component that embeds the canvas HTML
            string reactComponent = $@"import React from 'react';

const CanvasComponent = () => (
    <div dangerouslySetInnerHTML={{{{ __html: `{File.ReadAllText(outputPath)}` }}}} />
);

export default CanvasComponent;
";

            // Write the React component to a .jsx file
            string reactPath = "CanvasComponent.jsx";
            Directory.CreateDirectory(Path.GetDirectoryName(reactPath) ?? ".");
            File.WriteAllText(reactPath, reactComponent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert an SVG logo into a lightweight HTML5 canvas for faster rendering in a web app built with React.
 * 2. When you want to programmatically generate a React component that displays vector graphics without loading external image files.
 * 3. When you are building a .NET backend that prepares vector assets for client‑side canvas manipulation in a single‑page application.
 * 4. When you must embed scalable graphics into a React UI while keeping the markup minimal by exporting only the canvas tag.
 * 5. When you require automated conversion of multiple SVG files to canvas HTML and creation of corresponding JSX components during a build process.
 */
