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
            // Output BMP file path (hardcoded)
            string outputPath = @"C:\temp\star.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // BMP options with 24 bits per pixel
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for drawing the star
                Pen pen = new Pen(Color.Blue, 2);

                // Define star points (5-pointed star)
                // Outer points
                Point[] outer = new Point[]
                {
                    new Point(250, 50),   // top
                    new Point(320, 200),
                    new Point(470, 200),
                    new Point(350, 300),
                    new Point(400, 450),
                    new Point(250, 350),
                    new Point(100, 450),
                    new Point(150, 300),
                    new Point(30, 200),
                    new Point(180, 200)
                };

                // Draw lines between consecutive points and close the shape
                for (int i = 0; i < outer.Length; i++)
                {
                    Point start = outer[i];
                    Point end = outer[(i + 1) % outer.Length];
                    graphics.DrawLine(pen, start, end);
                }

                // Save the image (output path already bound to the source)
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
 * 1. When a developer needs to generate a 24‑bit BMP badge with a custom star logo using Aspose.Imaging’s Graphics.DrawLine method for a Windows desktop application.
 * 2. When an automated reporting tool must programmatically create a printable star‑shaped watermark on a 500×500 BMP image with C# and Aspose.Imaging.
 * 3. When a game asset pipeline requires drawing a blue star shape on a BMP background for sprite sheets using the Pen and Graphics classes.
 * 4. When a marketing system has to produce thumbnail images that include a star outline by drawing line segments and saving the result as a BMP file without external editors.
 * 5. When a data‑visualization service wants to render a star polygon as part of a chart legend and export it as a BMP for legacy compatibility.
 */