using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.jpg";
        string canvasOutputPath = @"C:\temp\canvas.html";
        string markdownOutputPath = @"C:\temp\image.md";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(canvasOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(markdownOutputPath));

        // Load the JPEG image and save it as an HTML5 Canvas (only the <canvas> tag)
        using (Image image = Image.Load(inputPath))
        {
            var canvasOptions = new Html5CanvasOptions
            {
                FullHtmlPage = false,          // Export only the canvas element
                CanvasTagId = "myCanvas"        // Optional identifier for the canvas tag
            };

            image.Save(canvasOutputPath, canvasOptions);
        }

        // Read the generated canvas HTML
        string canvasHtml = File.ReadAllText(canvasOutputPath);

        // Create Markdown content embedding the canvas element
        string markdownContent = "# Image Canvas\n\n" + canvasHtml + "\n";

        // Write the Markdown file
        File.WriteAllText(markdownOutputPath, markdownContent);
    }
}