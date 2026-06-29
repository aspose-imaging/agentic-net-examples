using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\polygon.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas (500x500)
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.White);

                // Create a pen with custom line join style
                Pen pen = new Pen(Color.Blue, 5f);
                pen.LineJoin = LineJoin.Round; // Custom line join

                // Define polygon points (a simple pentagon)
                Point[] polygonPoints = new Point[]
                {
                    new Point(250, 100),
                    new Point(350, 200),
                    new Point(300, 350),
                    new Point(200, 350),
                    new Point(150, 200)
                };

                // Draw the connected polygon
                graphics.DrawPolygon(pen, polygonPoints);

                // Save the image (output path already bound)
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
 * 1. When a developer needs to generate a high‑resolution BMP map overlay with smooth polygon edges for a GIS application, they can use this code to draw a pentagon with a round line join.
 * 2. When creating printable engineering diagrams in C# where the outlines must have consistent thickness and rounded corners, this snippet shows how to render a polygon onto a 24‑bit BMP file using Aspose.Imaging.
 * 3. When building a custom badge or logo generator that outputs BMP images for legacy systems, the code demonstrates how to draw a connected shape with a blue pen and custom line join style.
 * 4. When a game developer wants to pre‑render static terrain features as BMP textures with anti‑aliased polygon borders, they can employ this example to produce the assets programmatically.
 * 5. When automating the production of certification stamps that require a precise polygon shape with rounded joins in a BMP file, this code provides a straightforward way to create and save the image.
 */