using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.svg";
        string canvasOutputPath = @"C:\Output\canvas.html";
        string reactComponentPath = @"C:\Output\CanvasComponent.jsx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(canvasOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(reactComponentPath));

        // Load the vector image and export to HTML5 Canvas (canvas tag only)
        using (Image image = Image.Load(inputPath))
        {
            var canvasOptions = new Html5CanvasOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions(),
                FullHtmlPage = false,          // export only the canvas tag
                CanvasTagId = "myCanvas"       // identifier for the canvas element
            };

            image.Save(canvasOutputPath, canvasOptions);
        }

        // Read the generated canvas HTML
        string canvasHtml = File.ReadAllText(canvasOutputPath);

        // Escape backticks for embedding in a template literal
        string escapedCanvasHtml = canvasHtml.Replace("`", "\\`");

        // Build a simple React functional component that injects the canvas HTML
        string reactComponent = $@"import React from 'react';

const CanvasComponent = () => (
  <div dangerouslySetInnerHTML={{{{ __html: `{escapedCanvasHtml}` }}}} />
);

export default CanvasComponent;
";

        // Write the React component to file
        File.WriteAllText(reactComponentPath, reactComponent);
    }
}