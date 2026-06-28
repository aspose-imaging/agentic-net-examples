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
            string finalHtmlPath = Path.Combine(outputDir, "index.html");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(finalHtmlPath));

            // Collect canvas tags
            List<string> canvasTags = new List<string>();

            // Get JPEG files (both .jpg and .jpeg)
            string[] jpgFiles = Directory.GetFiles(inputDir, "*.jpg");
            string[] jpegFiles = Directory.GetFiles(inputDir, "*.jpeg");
            string[] allFiles = new string[jpgFiles.Length + jpegFiles.Length];
            jpgFiles.CopyTo(allFiles, 0);
            jpegFiles.CopyTo(allFiles, jpgFiles.Length);

            foreach (string inputPath in allFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Define output canvas file path
                string canvasFileName = Path.GetFileNameWithoutExtension(inputPath) + ".html";
                string outputCanvasPath = Path.Combine(outputDir, canvasFileName);

                // Ensure the directory for the canvas file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputCanvasPath));

                // Load the JPEG image and save as HTML5 Canvas (only the canvas tag)
                using (Image image = Image.Load(inputPath))
                {
                    var canvasOptions = new Html5CanvasOptions
                    {
                        FullHtmlPage = false // export only the <canvas> tag
                    };
                    image.Save(outputCanvasPath, canvasOptions);
                }

                // Read the generated canvas tag and store it
                string canvasTag = File.ReadAllText(outputCanvasPath);
                canvasTags.Add(canvasTag);
            }

            // Build the final HTML page containing all canvases
            string finalHtml = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>Canvas Gallery</title>
</head>
<body>
" + string.Join("\n", canvasTags) + @"
</body>
</html>";

            // Write the final HTML page
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
 * 1. When a web developer needs to quickly turn a folder of product photos in JPEG format into lightweight HTML5 canvas elements for an online catalog, this code batch‑converts the images and assembles them into a single HTML page.
 * 2. When an e‑learning platform wants to embed historical JPEG scans as interactive canvas drawings without loading separate image files, the script converts each scan to a canvas tag and aggregates them for fast page rendering.
 * 3. When a marketing team requires a printable HTML report that showcases a series of campaign JPEG banners as canvas elements for consistent styling across browsers, the code automates the conversion and creates one index.html file.
 * 4. When a QA engineer needs to verify that JPEG assets render correctly in HTML5 canvas across multiple browsers, they can use this C# routine to generate a single test page containing all canvases for visual inspection.
 * 5. When a content management system must migrate legacy JPEG assets to HTML5 canvas format for responsive design, the batch conversion script simplifies the process by producing individual canvas files and a combined HTML overview page.
 */