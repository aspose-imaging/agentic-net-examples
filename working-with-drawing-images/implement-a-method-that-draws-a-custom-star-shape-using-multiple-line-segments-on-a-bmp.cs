using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path for the BMP image
        string outputPath = @"c:\temp\star.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file create source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Define canvas size
            int width = 500;
            int height = 500;

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define star points (5-pointed star)
                Point[] starPoints = new Point[]
                {
                    new Point(250, 50),   // Top point
                    new Point(300, 200),
                    new Point(450, 200),
                    new Point(325, 300),
                    new Point(375, 450),
                    new Point(250, 350),
                    new Point(125, 450),
                    new Point(175, 300),
                    new Point(50, 200),
                    new Point(200, 200)
                };

                // Pen for drawing lines
                Pen pen = new Pen(Color.Blue, 2);

                // Draw lines between consecutive points and close the star shape
                for (int i = 0; i < starPoints.Length; i++)
                {
                    Point start = starPoints[i];
                    Point end = starPoints[(i + 1) % starPoints.Length];
                    graphics.DrawLine(pen, start, end);
                }

                // Save the image (output file is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a printable badge or certificate with a decorative star emblem saved as a BMP file using Aspose.Imaging in a C# application.
 * 2. When an e‑learning platform wants to create dynamic star‑shaped progress markers on the fly and store them as 24‑bit BMP images for legacy systems.
 * 3. When a game developer requires a simple star sprite generated at runtime without external assets, using Aspose.Imaging’s Graphics and Pen classes to draw line segments on a bitmap.
 * 4. When a reporting tool must embed a custom star watermark into scanned documents by programmatically drawing the shape onto a BMP canvas before merging with PDF output.
 * 5. When an IoT device with limited graphics libraries needs to render a star icon on a display buffer and save it as a BMP file for later transmission or archival.
 */