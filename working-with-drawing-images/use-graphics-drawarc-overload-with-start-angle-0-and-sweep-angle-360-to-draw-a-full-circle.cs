// HOW-TO: Create PNG Image with Full Circle Using Aspose.Imaging DrawArc C# (Aspose.Imaging for .NET)
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
            string outputPath = "circle.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            int width = 100;
            int height = 100;
            var options = new PngOptions();

            using (Image image = Image.Create(options, width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                var pen = new Pen(Color.Blue, 2);
                var rect = new Rectangle(10, 10, 80, 80);
                graphics.DrawArc(pen, rect, 0, 360);

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
 * 1. When you need to generate a PNG badge that contains a perfect blue circle for a web dashboard.
 * 2. When you want to programmatically create circular markers on a map image using Aspose.Imaging in a C# service.
 * 3. When an automated report requires a simple circular logo rendered on a white background without external graphics tools.
 * 4. When you are building a thumbnail generator that adds a circular outline around product photos in a .NET application.
 * 5. When you need to produce a vector‑like circle in a raster PNG for unit‑test verification of drawing APIs.
 */
