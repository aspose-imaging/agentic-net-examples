using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";
            string masterHtmlPath = Path.Combine(outputDir, "index.html");

            // Ensure input directory exists
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Collect canvas snippets
            List<string> canvasSnippets = new List<string>();

            // Get JPEG files (both .jpg and .jpeg)
            string[] jpgFiles = Directory.GetFiles(inputDir, "*.jpg");
            string[] jpegFiles = Directory.GetFiles(inputDir, "*.jpeg");
            List<string> allFiles = new List<string>();
            allFiles.AddRange(jpgFiles);
            allFiles.AddRange(jpegFiles);

            foreach (string inputPath in allFiles)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string canvasFileName = Path.GetFileNameWithoutExtension(inputPath) + ".html";
                string canvasPath = Path.Combine(outputDir, canvasFileName);

                // Ensure directory for canvas file exists
                Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));

                // Load JPEG and save as HTML5 Canvas (only canvas tag)
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(canvasPath, new Html5CanvasOptions { FullHtmlPage = false });
                }

                // Read the generated canvas snippet
                string canvasHtml = File.ReadAllText(canvasPath);
                canvasSnippets.Add(canvasHtml);
            }

            // Build the master HTML page
            string bodyContent = string.Join(Environment.NewLine, canvasSnippets);
            string masterHtml = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Canvas Gallery</title></head><body>"
                                + bodyContent
                                + "</body></html>";

            // Ensure directory for master HTML exists
            Directory.CreateDirectory(Path.GetDirectoryName(masterHtmlPath));

            // Write the master HTML file
            File.WriteAllText(masterHtmlPath, masterHtml);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}