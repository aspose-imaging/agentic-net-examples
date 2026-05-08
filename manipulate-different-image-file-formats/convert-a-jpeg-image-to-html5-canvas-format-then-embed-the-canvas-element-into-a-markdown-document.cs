using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string canvasPath = "canvas.html";
            string markdownPath = "output.md";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            string canvasDir = Path.GetDirectoryName(canvasPath);
            if (!string.IsNullOrEmpty(canvasDir))
            {
                Directory.CreateDirectory(canvasDir);
            }

            string markdownDir = Path.GetDirectoryName(markdownPath);
            if (!string.IsNullOrEmpty(markdownDir))
            {
                Directory.CreateDirectory(markdownDir);
            }

            // Load JPEG image and save as HTML5 Canvas (only the canvas tag)
            using (Image image = Image.Load(inputPath))
            {
                image.Save(canvasPath, new Html5CanvasOptions
                {
                    FullHtmlPage = false
                });
            }

            // Read the generated canvas tag
            string canvasHtml = File.ReadAllText(canvasPath);

            // Embed the canvas tag into a Markdown document
            using (StreamWriter writer = new StreamWriter(markdownPath))
            {
                writer.WriteLine("# Image Canvas");
                writer.WriteLine();
                writer.WriteLine(canvasHtml);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}