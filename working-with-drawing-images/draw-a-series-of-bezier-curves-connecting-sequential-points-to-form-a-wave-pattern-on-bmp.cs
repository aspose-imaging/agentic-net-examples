using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Output BMP file path
            string outputPath = "output\\wave.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Canvas size
            int width = 800;
            int height = 200;

            // BMP options
            BmpOptions bmpOptions = new BmpOptions();

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for the wave
                Pen pen = new Pen(Color.Blue, 2);

                // Points defining a series of cubic Bezier curves (wave pattern)
                Point[] points = new Point[]
                {
                    new Point(0, 100),
                    new Point(100, 0),
                    new Point(200, 200),
                    new Point(300, 100),

                    new Point(300, 100),
                    new Point(400, 0),
                    new Point(500, 200),
                    new Point(600, 100),

                    new Point(600, 100),
                    new Point(700, 0),
                    new Point(800, 200),
                    new Point(800, 100)
                };

                // Draw the connected Bezier curves
                graphics.DrawBeziers(pen, points);

                // Save the BMP image
                image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to programmatically create a BMP file with a blue wave pattern using Aspose.Imaging’s Graphics.DrawBeziers method for a Windows desktop UI.
 * 2. When converting audio amplitude data into a visual waveform by drawing sequential cubic Bezier curves on a BMP canvas for inclusion in technical reports.
 * 3. When generating a decorative header image in BMP format with a smooth wave separator that can be embedded in PDF or HTML documents.
 * 4. When producing large‑size test images to evaluate the rendering speed and memory usage of Aspose.Imaging’s C# drawing operations on an 800×200 canvas.
 * 5. When automating the creation of BMP assets for a game’s UI, such as a wavy progress bar background, by drawing connected Bezier curves with a Pen object.
 */