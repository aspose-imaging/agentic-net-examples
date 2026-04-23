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
        string canvasPath = @"canvas.html";
        string outputPath = @"output.html";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Save only the canvas tag (no full HTML page)
                var canvasOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = false
                };
                image.Save(canvasPath, canvasOptions);
            }

            // Read the generated canvas tag
            string canvasTag = File.ReadAllText(canvasPath);

            // Build a full HTML page embedding the canvas
            string htmlPage = $"<html><head><meta charset=\"UTF-8\"><title>Canvas Export</title></head><body>{canvasTag}</body></html>";

            // Write the final HTML page
            File.WriteAllText(outputPath, htmlPage);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}