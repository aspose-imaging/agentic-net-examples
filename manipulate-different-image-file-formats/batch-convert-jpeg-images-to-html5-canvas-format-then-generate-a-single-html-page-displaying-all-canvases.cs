using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";
            string finalHtmlPath = Path.Combine(outputDir, "AllCanvases.html");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(finalHtmlPath));

            // Collect canvas snippets
            List<string> canvasSnippets = new List<string>();

            // Get all JPEG files in the input directory
            string[] jpegFiles = Directory.GetFiles(inputDir, "*.jpg");
            int index = 0;

            foreach (string inputPath in jpegFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the JPEG image
                using (Image image = Image.Load(inputPath))
                {
                    // Define canvas output path
                    string canvasFileName = Path.GetFileNameWithoutExtension(inputPath) + ".html";
                    string canvasPath = Path.Combine(outputDir, canvasFileName);

                    // Ensure the directory for the canvas file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));

                    // Save as HTML5 Canvas (only the canvas tag)
                    var canvasOptions = new Html5CanvasOptions
                    {
                        FullHtmlPage = false,
                        CanvasTagId = $"canvas_{index}"
                    };
                    image.Save(canvasPath, canvasOptions);

                    // Read the generated canvas snippet
                    string canvasSnippet = File.ReadAllText(canvasPath);
                    canvasSnippets.Add(canvasSnippet);
                }

                index++;
            }

            // Build the final HTML page containing all canvases
            var htmlBuilder = new System.Text.StringBuilder();
            htmlBuilder.AppendLine("<!DOCTYPE html>");
            htmlBuilder.AppendLine("<html>");
            htmlBuilder.AppendLine("<head>");
            htmlBuilder.AppendLine("<meta charset=\"utf-8\"/>");
            htmlBuilder.AppendLine("<title>All Canvases</title>");
            htmlBuilder.AppendLine("</head>");
            htmlBuilder.AppendLine("<body>");

            foreach (string snippet in canvasSnippets)
            {
                htmlBuilder.AppendLine(snippet);
                htmlBuilder.AppendLine("<br/>");
            }

            htmlBuilder.AppendLine("</body>");
            htmlBuilder.AppendLine("</html>");

            // Write the final HTML file
            File.WriteAllText(finalHtmlPath, htmlBuilder.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}