using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"input.png";
        string outputPath = @"output.html";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Configure HTML5 Canvas export options
            var options = new Html5CanvasOptions
            {
                // Generate a full HTML page containing the canvas element
                FullHtmlPage = true,
                // Optional: set a custom canvas tag identifier
                CanvasTagId = "myCanvas"
            };

            // Save the image as an HTML5 Canvas page
            image.Save(outputPath, options);
        }

        Console.WriteLine($"Canvas HTML page saved to: {outputPath}");
    }
}