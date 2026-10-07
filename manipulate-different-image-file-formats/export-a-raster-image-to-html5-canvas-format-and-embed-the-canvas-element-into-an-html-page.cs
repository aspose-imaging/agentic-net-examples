// HOW-TO: Export PNG to HTML5 Canvas HTML with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.png";
            string outputPath = "Output/canvas.html";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Html5CanvasOptions options = new Html5CanvasOptions();
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display a server‑side PNG image on a web page without using an <img> tag, you can convert it to an HTML5 canvas element and embed the generated HTML.
 * 2. When building a reporting dashboard that must render raster graphics directly in the browser, you can export the image to a canvas‑based HTML file using Aspose.Imaging for C#.
 * 3. When creating an interactive e‑learning module that requires pixel‑perfect rendering of PNG assets on a canvas, this code converts the image to a canvas element that can be scripted with JavaScript.
 * 4. When you want to embed a PNG into an HTML email or static site where only HTML is allowed, converting the image to a canvas element ensures it displays without external image files.
 * 5. When automating a build pipeline that generates documentation with embedded graphics, you can programmatically turn each PNG into an HTML5 canvas snippet for seamless integration.
 */
