using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\temp\input.jpg";
        string canvasPath = @"C:\temp\canvas.html";
        string markdownPath = @"C:\temp\output.md";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));
        Directory.CreateDirectory(Path.GetDirectoryName(markdownPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Save only the <canvas> tag (no full HTML page)
            var canvasOptions = new Html5CanvasOptions
            {
                FullHtmlPage = false
                // For raster images no additional rasterization options are required
            };
            image.Save(canvasPath, canvasOptions);
        }

        // Read the generated canvas HTML
        string canvasHtml = File.ReadAllText(canvasPath);

        // Build markdown content embedding the canvas element
        string markdownContent = "# Image Canvas\n\n" + canvasHtml + "\n";

        // Write markdown file
        File.WriteAllText(markdownPath, markdownContent);
    }
}