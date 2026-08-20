// HOW-TO: Create a 300x200 BMP with Black Ellipse Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"c:\temp\ellipse.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            var source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(options, 300, 200))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawEllipse(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1),
                    new Aspose.Imaging.Rectangle(0, 0, 300, 200));
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
 * 1. When you need to generate a simple placeholder image with an ellipse for a report or UI mockup in BMP format.
 * 2. When a server‑side application must programmatically create a black‑outlined ellipse inside a fixed‑size bitmap for printing or legacy systems.
 * 3. When you want to automate the production of diagram assets, such as icons or badges, by drawing vector shapes onto a BMP file using C#.
 * 4. When integrating with a workflow that requires BMP images, and you must draw geometric shapes without using GDI+.
 * 5. When creating test images for image‑processing algorithms that expect a 300 × 200 BMP containing a single ellipse.
 */
