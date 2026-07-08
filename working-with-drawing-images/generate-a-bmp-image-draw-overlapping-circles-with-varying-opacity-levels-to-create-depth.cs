using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hardcoded)
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a blank BMP image of size 500x500
            using (Image image = Image.Create(new BmpOptions(), 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // First circle: semi‑transparent red
                using (SolidBrush brush1 = new SolidBrush(Color.Red))
                {
                    brush1.Opacity = 0.5f; // 50% opacity
                    graphics.FillEllipse(brush1, new Rectangle(50, 50, 300, 300));
                }

                // Second circle: semi‑transparent green, overlapping the first
                using (SolidBrush brush2 = new SolidBrush(Color.Green))
                {
                    brush2.Opacity = 0.4f; // 40% opacity
                    graphics.FillEllipse(brush2, new Rectangle(150, 150, 300, 300));
                }

                // Third circle: semi‑transparent blue, overlapping the others
                using (SolidBrush brush3 = new SolidBrush(Color.Blue))
                {
                    brush3.Opacity = 0.3f; // 30% opacity
                    graphics.FillEllipse(brush3, new Rectangle(250, 250, 300, 300));
                }

                // Save the image as BMP
                image.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to generate a BMP thumbnail with layered semi‑transparent circles to illustrate data density in a desktop reporting tool.
 * 2. When creating a simple visual placeholder image for a UI mockup where overlapping colored ellipses with varying opacity convey depth without external assets.
 * 3. When producing test images for validating an image‑processing pipeline that must handle BMP files, alpha blending, and ellipse drawing using C# and Aspose.Imaging.
 * 4. When automating the creation of custom Windows application icons that require overlapping colored circles with different opacity levels to indicate status levels.
 * 5. When generating educational graphics for a tutorial on compositing and opacity effects, using C# code to draw and save BMP images with Aspose.Imaging.
 */