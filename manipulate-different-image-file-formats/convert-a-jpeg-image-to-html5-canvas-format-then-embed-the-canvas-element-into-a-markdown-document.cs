// HOW-TO: Convert JPEG to HTML5 Canvas and Embed in Markdown with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string htmlOutputPath = "output.html";
            string markdownPath = "output.md";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string htmlDir = Path.GetDirectoryName(htmlOutputPath);
            if (!string.IsNullOrEmpty(htmlDir))
                Directory.CreateDirectory(htmlDir);

            string markdownDir = Path.GetDirectoryName(markdownPath);
            if (!string.IsNullOrEmpty(markdownDir))
                Directory.CreateDirectory(markdownDir);

            using (Image image = Image.Load(inputPath))
            {
                Html5CanvasOptions options = new Html5CanvasOptions
                {
                    Source = new FileCreateSource(htmlOutputPath, false)
                };
                image.Save(htmlOutputPath, options);
            }

            string htmlContent = File.ReadAllText(htmlOutputPath);
            File.WriteAllText(markdownPath, htmlContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display a JPEG image on a static site that only supports Markdown, you can convert it to an HTML5 canvas element and embed it directly in the Markdown file.
 * 2. When generating technical documentation programmatically, this code lets you include high‑resolution images as canvas markup without relying on external image files.
 * 3. When creating a blog post that will be rendered by a Markdown parser that strips image tags, you can embed the picture as a canvas to ensure it appears correctly.
 * 4. When building an automated report that combines images and code snippets, the conversion to canvas and insertion into Markdown keeps the layout portable and self‑contained.
 * 5. When you want to store images in a version‑controlled repository without binary blobs, converting JPEGs to canvas HTML and saving them in Markdown reduces binary storage while preserving visual content.
 */
