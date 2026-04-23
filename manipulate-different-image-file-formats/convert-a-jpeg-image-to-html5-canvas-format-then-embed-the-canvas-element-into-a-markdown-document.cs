using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input JPEG path
            string inputPath = @"C:\temp\input.jpg";

            // Hard‑coded output HTML5 Canvas file path
            string htmlOutputPath = @"C:\temp\canvas.html";

            // Hard‑coded output Markdown file path
            string markdownPath = @"C:\temp\image.md";

            // Verify that the input JPEG exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the directory for the HTML output exists
            Directory.CreateDirectory(Path.GetDirectoryName(htmlOutputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as an HTML5 Canvas fragment (only the <canvas> tag)
                var canvasOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = false,                     // export only the canvas tag
                    CanvasTagId = "myCanvas",                  // optional canvas identifier
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };

                image.Save(htmlOutputPath, canvasOptions);
            }

            // Read the generated <canvas> tag
            string canvasTag = File.ReadAllText(htmlOutputPath);

            // Ensure the directory for the Markdown file exists
            Directory.CreateDirectory(Path.GetDirectoryName(markdownPath));

            // Create a simple Markdown document embedding the canvas tag
            string markdownContent = "# Image Canvas\n\n" + canvasTag + "\n";

            File.WriteAllText(markdownPath, markdownContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}