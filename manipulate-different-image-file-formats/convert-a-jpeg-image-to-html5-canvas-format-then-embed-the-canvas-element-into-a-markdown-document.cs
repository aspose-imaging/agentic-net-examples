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

        try
        {
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
                // Save as HTML5 Canvas (only the canvas tag)
                var canvasOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = false
                };
                image.Save(canvasPath, canvasOptions);
            }

            // Read the generated canvas HTML
            string canvasHtml = File.ReadAllText(canvasPath);

            // Create Markdown content embedding the canvas element
            string markdownContent = "# Canvas Image\n\n" + canvasHtml + "\n";

            // Write the Markdown file
            File.WriteAllText(markdownPath, markdownContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a JPEG photo into an HTML5 Canvas snippet for embedding directly in a Markdown README, this code automates the conversion using Aspose.Imaging for .NET.
 * 2. When creating technical documentation that includes interactive image previews, the code transforms JPEG assets into canvas elements that render in browsers without external image files.
 * 3. When generating static site content where images must be displayed via HTML5 Canvas for consistent styling, the snippet converts the JPEG and inserts the canvas tag into a Markdown page.
 * 4. When building a C# utility that prepares image assets for a developer blog, this example shows how to load a JPEG, save it as a canvas HTML fragment, and embed it in Markdown for seamless publishing.
 * 5. When automating a workflow that packages image resources into a single Markdown file for version‑controlled repositories, the code uses Aspose.Imaging to produce a lightweight canvas representation of the JPEG.
 */