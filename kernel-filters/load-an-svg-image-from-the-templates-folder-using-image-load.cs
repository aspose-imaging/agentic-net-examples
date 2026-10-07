// HOW-TO: Load SVG Image From Templates Folder and Get Dimensions in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "templates/template.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                Console.WriteLine($"Loaded SVG image. Width: {image.Width}, Height: {image.Height}");
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
 * 1. When you need to read an SVG file from a predefined templates directory to obtain its width and height for layout calculations in a C# application.
 * 2. When you want to verify that a template SVG exists and retrieve its dimensions before rendering it on a web page.
 * 3. When you are processing a batch of SVG templates and need to log each image’s size for quality‑control reporting.
 * 4. When you must ensure an SVG asset can be opened without errors before converting it to another format such as PNG or PDF.
 * 5. When you are building a preview feature that displays basic metadata, like dimensions, of a selected SVG template in a desktop tool.
 */
