// HOW-TO: Draw a 180 Degree Arc in a 400x200 Rectangle with C# (Aspose.Imaging for .NET)
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
            // Output file path (hardcoded)
            string outputPath = @"C:\temp\arc.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a PNG image with a canvas size larger than the rectangle
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                var pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                using (Image image = Image.Create(pngOptions, 500, 300))
                {
                    // Initialize graphics for drawing
                    var graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    // Define the rectangle and draw the arc
                    var pen = new Pen(Color.Black, 2);
                    var rect = new Rectangle(50, 50, 400, 200); // x, y, width, height
                    graphics.DrawArc(pen, rect, 45, 180);

                    // Save the image
                    image.Save();
                }
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
 * 1. When you need to generate a PNG diagram that includes a semi‑circular shape positioned within a specific rectangular area, such as a gauge or progress indicator.
 * 2. When creating dynamic report graphics where an arc represents a range of values, like a temperature range on a dashboard.
 * 3. When producing custom UI assets programmatically, for example drawing a curved underline or decorative element in a 400 × 200 canvas.
 * 4. When automating the generation of printable schematics that require precise arc angles, such as engineering diagrams or architectural plans.
 * 5. When building a server‑side image service that returns PNG images with arcs based on user‑provided parameters for web or mobile applications.
 */
