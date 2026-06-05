using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\polygon.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options and specify the file to create
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 400x400 BMP image
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Create a pen with custom line join style
                Pen pen = new Pen(Color.Blue, 5);
                pen.LineJoin = LineJoin.Round; // custom join style

                // Define polygon vertices
                Point[] points = new Point[]
                {
                    new Point(50, 300),
                    new Point(200, 50),
                    new Point(350, 300),
                    new Point(50, 150) // additional point to keep polygon connected
                };

                // Draw the polygon
                graphics.DrawPolygon(pen, points);

                // Save the image to the specified path
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
 * 1. When a developer needs to generate a 24‑bit BMP thumbnail with a custom‑styled polygon overlay for a reporting dashboard.
 * 2. When a C# application must create a printable 400×400 bitmap showing a highlighted area using a rounded‑join pen for architectural diagrams.
 * 3. When an automated image‑processing pipeline requires drawing connected polygonal boundaries on a BMP file to mark regions of interest in medical imaging.
 * 4. When a game‑level editor needs to export level outlines as 24‑bit BMP images with smooth polygon edges for asset previews.
 * 5. When a data‑visualization tool wants to render a custom‑shaped marker on a bitmap background and save it directly to disk without intermediate streams.
 */