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
        string canvasHtmlPath = @"C:\Images\canvas.html";
        string reactComponentPath = @"C:\Images\CanvasComponent.jsx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(canvasHtmlPath));
        Directory.CreateDirectory(Path.GetDirectoryName(reactComponentPath));

        // Load the vector image and export only the <canvas> tag
        using (var image = Image.Load(inputPath))
        {
            var options = new Html5CanvasOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions(),
                FullHtmlPage = false,          // export only the canvas tag
                CanvasTagId = "myCanvas"        // optional canvas id
            };
            image.Save(canvasHtmlPath, options);
        }

        // Read the generated canvas HTML
        string canvasHtml = File.ReadAllText(canvasHtmlPath);

        // Escape backticks for embedding in a JavaScript template literal
        string escapedCanvasHtml = canvasHtml.Replace("`", "\\`");

        // Build a simple React component that injects the canvas HTML
        string reactComponentCode = $@"import React from 'react';

const CanvasComponent = () => (
  <div dangerouslySetInnerHTML={{{{ __html: `{escapedCanvasHtml}` }}}} />
);

export default CanvasComponent;
";

        // Write the React component to file
        File.WriteAllText(reactComponentPath, reactComponentCode);
    }
}