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
        string canvasOutputPath = @"C:\Images\Canvas.html";
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

            // Load the vector image
            using (var image = Image.Load(inputPath))
            {
                // Export only the <canvas> tag (no full HTML page)
                var options = new Html5CanvasOptions
                {
                    FullHtmlPage = false,
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };

                image.Save(canvasOutputPath, options);
            }

            // Read the generated canvas HTML
            string canvasHtml = File.ReadAllText(canvasOutputPath);

            // Escape backticks for embedding in a template literal
            string escapedCanvasHtml = canvasHtml.Replace("`", "\\`");

            // Build a simple React component that injects the canvas HTML
            string reactComponent = 
$@"import React from 'react';

const CanvasComponent = () => (
  <div dangerouslySetInnerHTML={{ __html: `{escapedCanvasHtml}` }} />
);

export default CanvasComponent;
";

            // Write the React component to file
            File.WriteAllText(reactComponentPath, reactComponent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}