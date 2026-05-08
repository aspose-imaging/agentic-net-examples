using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded output file path
        string outputPath = @"C:\temp\arc_output.png";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file‑create source
            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image (width 500, height 300) to contain the rectangle
            using (Image image = Image.Create(pngOptions, 500, 300))
            {
                // Initialize graphics object for drawing
                var graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Define the rectangle (x, y, width, height) = (50, 50, 400, 200)
                var rect = new Rectangle(50, 50, 400, 200);

                // Create a black pen with thickness 2
                var pen = new Pen(Color.Black, 2);

                // Draw an arc starting at 45° and sweeping 180° inside the rectangle
                graphics.DrawArc(pen, rect, 45, 180);

                // Save the image (the file was already created by the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}