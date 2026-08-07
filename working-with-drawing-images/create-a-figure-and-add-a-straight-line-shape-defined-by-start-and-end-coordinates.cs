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
            string outputPath = @"c:\temp\line.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                float x1 = 20f, y1 = 30f, x2 = 180f, y2 = 150f;
                graphics.DrawLine(new Pen(Color.Black, 2), x1, y1, x2, y2);

                image.Save();
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
 * 1. When a developer needs to generate a simple PNG diagram with a black line for a web report or email attachment using Aspose.Imaging for .NET.
 * 2. When an application must programmatically create a placeholder image with a straight line to indicate a missing photo in a content management system.
 * 3. When a C# service creates custom chart markers by drawing lines on a 200x200 canvas and saving them as PNG files for a dashboard.
 * 4. When a developer wants to add a visual separator between UI elements by drawing a line onto an image file during automated PDF generation.
 * 5. When a testing tool requires a deterministic PNG image with a known line geometry to validate image comparison algorithms.
 */