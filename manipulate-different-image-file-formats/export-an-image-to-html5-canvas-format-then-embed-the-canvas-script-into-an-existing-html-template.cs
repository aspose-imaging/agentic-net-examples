// HOW-TO: Export JPEG to HTML5 Canvas and Embed in HTML Template C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputCanvasPath = "output_canvas.html";
            string templatePath = "template.html";
            string finalHtmlPath = "final.html";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!File.Exists(templatePath))
            {
                Console.Error.WriteLine($"File not found: {templatePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputCanvasPath));
            Directory.CreateDirectory(Path.GetDirectoryName(finalHtmlPath));

            using (Image image = Image.Load(inputPath))
            {
                Html5CanvasOptions options = new Html5CanvasOptions();
                image.Save(outputCanvasPath, options);
            }

            string canvasContent = File.ReadAllText(outputCanvasPath);
            string templateContent = File.ReadAllText(templatePath);
            string finalContent = templateContent.Replace("{{CANVAS_SCRIPT}}", canvasContent);
            File.WriteAllText(finalHtmlPath, finalContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a JPEG image into a self‑contained HTML5 canvas script for display in browsers without external image files.
 * 2. When you want to integrate a generated canvas element into an existing HTML page using a placeholder token.
 * 3. When you are building a reporting tool that embeds processed images directly into HTML reports via Aspose.Imaging.
 * 4. When you must automate the creation of offline web pages that render images on a canvas for better compatibility with mobile devices.
 * 5. When you are developing a C# backend that prepares image‑rich email templates by inserting canvas scripts into predefined HTML layouts.
 */
