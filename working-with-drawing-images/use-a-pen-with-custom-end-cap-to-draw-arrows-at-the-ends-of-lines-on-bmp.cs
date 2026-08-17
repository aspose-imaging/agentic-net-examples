// HOW-TO: Draw Arrow Lines on BMP Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            // Output BMP path
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options with file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, 300, 200))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create pen with arrow end cap
                Pen pen = new Pen(Color.Black, 2f);
                pen.EndCap = LineCap.ArrowAnchor; // Arrow at the end of the line

                // Draw lines with arrows
                graphics.DrawLine(pen, new Point(50, 50), new Point(250, 50));
                graphics.DrawLine(pen, new Point(50, 100), new Point(250, 150));
                graphics.DrawLine(pen, new Point(50, 150), new Point(250, 100));

                // Save the image (bound to the file source)
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
 * 1. When you need to generate a BMP diagram that shows directional flow with arrow‑head lines for documentation or UI overlays.
 * 2. When creating technical schematics in C# where arrows indicate vector directions on a bitmap background.
 * 3. When exporting annotated screenshots as BMP files and you want to highlight actions with arrow‑ended lines.
 * 4. When building a reporting tool that draws process steps on a BMP canvas, using a Pen with custom end caps for clear visual cues.
 * 5. When automating the creation of printable wiring diagrams in .NET and require arrow markers on lines to denote signal flow.
 */
