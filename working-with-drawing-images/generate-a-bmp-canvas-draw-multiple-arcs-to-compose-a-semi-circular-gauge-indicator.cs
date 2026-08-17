// HOW-TO: Create BMP Gauge Indicator with Multiple Arcs in C# (Aspose.Imaging for .NET)
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
            // Output BMP file path
            string outputPath = @"C:\temp\gauge.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source for the BMP image
            FileCreateSource source = new FileCreateSource(outputPath, false);

            // Set BMP options
            BmpOptions options = new BmpOptions()
            {
                Source = source,
                BitsPerPixel = 24
            };

            // Create a BMP canvas (width: 400, height: 200)
            using (Image canvas = Image.Create(options, 400, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Clear background
                graphics.Clear(Color.White);

                // Draw background semi‑circular arc (light gray)
                Pen backgroundPen = new Pen(Color.LightGray, 10);
                graphics.DrawArc(backgroundPen, new Rectangle(50, 50, 300, 300), 180, -180);

                // Draw gauge range arc (green)
                Pen rangePen = new Pen(Color.Green, 10);
                graphics.DrawArc(rangePen, new Rectangle(70, 70, 260, 260), 180, -180);

                // Draw indicator arc (red)
                Pen indicatorPen = new Pen(Color.Red, 10);
                graphics.DrawArc(indicatorPen, new Rectangle(90, 90, 220, 220), 180, -180);

                // Save the image (bound to the file source)
                canvas.Save();
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
 * 1. When you need to generate a semi‑circular gauge image as a BMP file for dashboards or reports.
 * 2. When you want to programmatically draw custom arcs to represent ranges and pointers in a speedometer‑style visualization.
 * 3. When you must create a high‑resolution BMP canvas and clear the background before adding vector graphics in a .NET application.
 * 4. When you are building an automated system that outputs gauge indicators for IoT device status without using external design tools.
 * 5. When you require a simple way to save drawn graphics directly to a file source using Aspose.Imaging’s BmpOptions in C#.
 */
