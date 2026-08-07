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
            // Output file path (hard‑coded)
            string outputPath = @"C:\temp\arc_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a bound source for the BMP file
            Source source = new FileCreateSource(outputPath, false);

            // Set up BMP options with the source
            BmpOptions bmpOptions = new BmpOptions
            {
                Source = source
            };

            // Create a 500×500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background
                graphics.Clear(Color.White);

                // Define a pen for the arc
                Pen pen = new Pen(Color.Blue, 2);

                // Define the rectangle that bounds the arc
                Rectangle rect = new Rectangle(100, 100, 300, 300);

                // Draw a 90‑degree arc (start angle 0, sweep angle 90)
                graphics.DrawArc(pen, rect, 0, 90);

                // Save the bound image (no path needed)
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
 * 1. When a developer needs to generate a BMP thumbnail with a 90‑degree blue arc overlay for a legacy Windows application UI.
 * 2. When an engineering tool must programmatically add a quarter‑circle arc to a bitmap diagram that will be saved as a BMP file for CNC machine panels.
 * 3. When a game‑asset pipeline requires creating simple BMP sprites with a 90‑degree arc shape using C# without manual image editing.
 * 4. When a reporting system has to embed a blue arc into a BMP chart to highlight a specific data range before exporting the image.
 * 5. When an IoT device firmware generates a BMP status image that includes a 90‑degree arc to indicate a sensor’s activation zone.
 */