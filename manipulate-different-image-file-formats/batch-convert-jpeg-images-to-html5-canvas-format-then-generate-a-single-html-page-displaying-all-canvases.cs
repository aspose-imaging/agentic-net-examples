using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected errors
        try
        {
            // Hard‑coded input and output locations
            string inputDir = @"C:\Images\Input";
            string canvasDir = @"C:\Images\Canvas";
            string finalHtmlPath = @"C:\Images\output.html";

            // Ensure the canvas output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(canvasDir));

            // Collect generated canvas snippets
            List<string> canvasSnippets = new List<string>();

            // Get all JPEG files in the input directory
            string[] jpegFiles = Directory.GetFiles(inputDir, "*.jpg");

            foreach (string jpegPath in jpegFiles)
            {
                // Verify the source file exists
                if (!File.Exists(jpegPath))
                {
                    Console.Error.WriteLine($"File not found: {jpegPath}");
                    return;
                }

                // Load the JPEG image
                using (Image image = Image.Load(jpegPath))
                {
                    // Determine the canvas file path
                    string canvasPath = Path.Combine(canvasDir,
                        Path.GetFileNameWithoutExtension(jpegPath) + ".html");

                    // Ensure the directory for the canvas file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));

                    // Save only the canvas tag (no full HTML page)
                    var canvasOptions = new Html5CanvasOptions
                    {
                        FullHtmlPage = false
                    };
                    image.Save(canvasPath, canvasOptions);

                    // Read the generated canvas snippet
                    string canvasHtml = File.ReadAllText(canvasPath);
                    canvasSnippets.Add(canvasHtml);
                }
            }

            // Build the final HTML page that embeds all canvases
            string finalHtml = "<!DOCTYPE html>\n<html>\n<head>\n<meta charset=\"UTF-8\">\n<title>Canvas Gallery</title>\n</head>\n<body>\n";

            foreach (string snippet in canvasSnippets)
            {
                finalHtml += snippet + "\n";
            }

            finalHtml += "</body>\n</html>";

            // Ensure the directory for the final HTML file exists
            Directory.CreateDirectory(Path.GetDirectoryName(finalHtmlPath));

            // Write the combined HTML page
            File.WriteAllText(finalHtmlPath, finalHtml);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch convert a collection of JPEG photos into HTML5 canvas snippets for embedding in a lightweight web gallery without loading full HTML pages.
 * 2. When an e‑learning platform wants to transform stored JPEG images into canvas elements that can be dynamically styled or animated with JavaScript.
 * 3. When a digital asset management system requires generating a single HTML report that displays all JPEG assets as canvas drawings for quick visual inspection.
 * 4. When a marketing team aims to create an offline HTML5 portfolio by converting JPEG campaign images to canvas tags and assembling them into one consolidated HTML file.
 * 5. When a C# application must automate the migration of legacy JPEG files to HTML5 canvas format to improve page‑load performance and enable client‑side image manipulation.
 */