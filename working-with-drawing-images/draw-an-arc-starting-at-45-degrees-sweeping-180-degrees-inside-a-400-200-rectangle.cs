// HOW-TO: Draw a 180 Degree Arc in a 400x200 PNG with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/arc.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        try
        {
            var options = new PngOptions();
            using (var image = Image.Create(options, 400, 200))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);
                var pen = new Pen(Color.Black, 2);
                var rect = new Rectangle(0, 0, 400, 200);
                graphics.DrawArc(pen, rect, 45f, 180f);
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
 * 1. When generating a custom gauge or semi‑circular progress indicator for a dashboard and need to render it as a PNG image in C#.
 * 2. When creating a printable report that includes a decorative half‑circle border around a chart using Aspose.Imaging.
 * 3. When building a game UI that requires a curved health‑bar segment drawn dynamically at runtime.
 * 4. When automating the production of vector‑style graphics such as arcs for marketing banners without using external design tools.
 * 5. When developing a scientific visualization that plots angular data as arcs inside a fixed‑size image for inclusion in documentation.
 */
