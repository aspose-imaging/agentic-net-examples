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
        string canvasSnippetPath = "canvas.html";
        string outputHtmlPath = "output.html";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(canvasSnippetPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputHtmlPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Save only the canvas tag (no full HTML page)
            var canvasOptions = new Html5CanvasOptions
            {
                FullHtmlPage = false,
                CanvasTagId = "myCanvas"
            };
            image.Save(canvasSnippetPath, canvasOptions);
        }

        // Read the generated canvas snippet
        string canvasTag = File.ReadAllText(canvasSnippetPath);

        // Build a simple HTML page that embeds the canvas tag
        string htmlPage = $@"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"">
    <title>Canvas Image</title>
</head>
<body>
    {canvasTag}
</body>
</html>";

        // Write the final HTML page
        File.WriteAllText(outputHtmlPath, htmlPage);
    }
}