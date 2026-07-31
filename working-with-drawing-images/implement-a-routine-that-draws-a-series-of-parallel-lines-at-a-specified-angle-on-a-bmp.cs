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
            // Output BMP file path
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Image dimensions
            int width = 800;
            int height = 600;

            // Parallel lines parameters
            double angleDegrees = 45.0; // angle of lines
            int spacing = 20;           // distance between lines in pixels

            // Prepare BMP options with bound file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Pen for drawing lines
                Pen pen = new Pen(Color.Black, 1);

                // Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Convert angle to radians and compute tangent
                double rad = angleDegrees * Math.PI / 180.0;
                double tan = Math.Tan(rad);

                // Draw lines with varying intercept (b) to cover the canvas
                for (double b = -height; b <= height; b += spacing)
                {
                    // Start point at left edge (x = 0)
                    int x1 = 0;
                    int y1 = (int)Math.Round(b);

                    // End point at right edge (x = width)
                    int x2 = width;
                    int y2 = (int)Math.Round(tan * width + b);

                    graphics.DrawLine(pen, x1, y1, x2, y2);
                }

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
 * 1. When a developer needs to generate a BMP watermark pattern of diagonal hatch lines at a custom angle using Aspose.Imaging in C#.
 * 2. When an application must create a printable grid overlay with evenly spaced parallel lines for engineering drawings saved as BMP files.
 * 3. When a game engine requires procedural generation of textured floor tiles with slanted parallel lines and needs to export the result as a BMP image.
 * 4. When a reporting tool wants to add slanted line shading to chart backgrounds and store the final graphic as a BMP using C# graphics operations.
 * 5. When a web service produces custom security stamp patterns with adjustable line spacing and angle and saves them in BMP format.
 */