using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace AsposeCanvasExport
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output paths
                string inputPath = @"C:\Images\sample.svg";
                string htmlOutputPath = @"C:\Output\Canvas.html";
                string reactComponentPath = @"C:\Output\CanvasComponent.jsx";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directories exist
                Directory.CreateDirectory(Path.GetDirectoryName(htmlOutputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(reactComponentPath));

                // Load vector image and export to HTML5 Canvas
                using (var image = Image.Load(inputPath))
                {
                    var options = new Html5CanvasOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions(),
                        FullHtmlPage = true
                    };
                    image.Save(htmlOutputPath, options);
                }

                // Read generated HTML content
                string htmlContent = File.ReadAllText(htmlOutputPath);
                // Escape characters for inclusion in a JavaScript template literal
                string escapedHtml = htmlContent.Replace("\\", "\\\\").Replace("`", "\\`");

                // Create React component source code
                string componentCode = $@"import React from 'react';

const CanvasComponent = () => (
    <div dangerouslySetInnerHTML={{{{ __html: `{escapedHtml}` }}}} />
);

export default CanvasComponent;
";

                // Write React component to file
                File.WriteAllText(reactComponentPath, componentCode);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}