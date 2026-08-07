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
            // Define output path
            string outputPath = @"c:\temp\concentric_ellipses.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas (500x500)
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Parameters for concentric ellipses
                int centerX = 250;
                int centerY = 250;
                int maxRadius = 200;
                int step = 40;
                int ellipseCount = 5;

                // Draw ellipses with alternating colors
                for (int i = 0; i < ellipseCount; i++)
                {
                    int radius = maxRadius - i * step;
                    int x = centerX - radius;
                    int y = centerY - radius;
                    int diameter = radius * 2;

                    // Alternate between Red and Blue
                    Color penColor = (i % 2 == 0) ? Color.Red : Color.Blue;
                    Pen pen = new Pen(penColor, 3);

                    // Draw the ellipse
                    graphics.DrawEllipse(pen, x, y, diameter, diameter);
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
 * 1. When a developer needs to generate a 24‑bit BMP file that visualizes data as concentric ellipses with alternating red and blue colors for a scientific report, this code provides a ready‑to‑use solution.
 * 2. When creating a simple placeholder image for UI testing that requires a 500 × 500 bitmap with layered ellipses, the snippet automates the drawing and saving process using Aspose.Imaging.
 * 3. When building a custom charting component that represents hierarchical levels with nested ellipses, this example demonstrates how to render each level with alternating colors via the Graphics API.
 * 4. When a game developer wants to programmatically generate texture assets such as target symbols stored as BMP images, the code shows how to draw the target’s rings with alternating colors in C#.
 * 5. When automating the production of printable badges that include a decorative concentric‑ellipse background, this code can be integrated into a C# workflow to create the BMP background on the fly.
 */