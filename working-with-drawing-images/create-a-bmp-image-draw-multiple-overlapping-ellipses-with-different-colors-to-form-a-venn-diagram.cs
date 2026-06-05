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
        string outputPath = @"c:\temp\venn.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Draw three overlapping ellipses with different colors
                // Red ellipse
                graphics.DrawEllipse(new Pen(Color.Red, 5), new Rectangle(100, 150, 200, 200));

                // Green ellipse (shifted right)
                graphics.DrawEllipse(new Pen(Color.Green, 5), new Rectangle(200, 150, 200, 200));

                // Blue ellipse (shifted down)
                graphics.DrawEllipse(new Pen(Color.Blue, 5), new Rectangle(150, 250, 200, 200));

                // Save the image
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
 * 1. When a developer needs to generate a BMP file that visualizes overlapping data sets as a Venn diagram for inclusion in a Windows desktop report.
 * 2. When an application must programmatically create a 500×500 bitmap with colored ellipses to illustrate set intersections in educational software without using external image editors.
 * 3. When a C# service creates thumbnail previews of statistical diagrams by drawing red, green, and blue ellipses onto a white background using Aspose.Imaging.
 * 4. When a legacy system requires BMP images with 24‑bit color depth for printing labels that contain simple geometric shapes representing product categories.
 * 5. When an automated testing tool needs to produce sample BMP images with multiple overlapping shapes to validate image‑processing pipelines that handle ellipse detection.
 */