using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\circle.png";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new 500x500 image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                var graphics = new Graphics(image);

                // Optional: clear background
                graphics.Clear(Color.White);

                // Define a pen for the circle outline
                var pen = new Pen(Color.Black, 2);

                // Draw a full circle using DrawArc (startAngle = 0, sweepAngle = 360)
                // Rectangle defines the bounding box of the ellipse (circle)
                graphics.DrawArc(pen, new Rectangle(100, 100, 300, 300), 0, 360);

                // Save the image (the file is already linked via the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            // Output any errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}