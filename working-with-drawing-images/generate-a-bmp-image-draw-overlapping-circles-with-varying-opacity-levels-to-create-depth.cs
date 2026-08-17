// HOW-TO: Create BMP with Overlapping Transparent Circles in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"c:\temp\circles.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // First circle (red) with low opacity
                using (SolidBrush brush1 = new SolidBrush())
                {
                    brush1.Color = Color.FromArgb(255, 255, 0, 0);
                    brush1.Opacity = 0.3f; // 30% opaque
                    graphics.FillEllipse(brush1, new Rectangle(50, 50, 200, 200));
                }

                // Second circle (green) with medium opacity
                using (SolidBrush brush2 = new SolidBrush())
                {
                    brush2.Color = Color.FromArgb(255, 0, 255, 0);
                    brush2.Opacity = 0.5f; // 50% opaque
                    graphics.FillEllipse(brush2, new Rectangle(150, 100, 200, 200));
                }

                // Third circle (blue) with higher opacity
                using (SolidBrush brush3 = new SolidBrush())
                {
                    brush3.Color = Color.FromArgb(255, 0, 0, 255);
                    brush3.Opacity = 0.7f; // 70% opaque
                    graphics.FillEllipse(brush3, new Rectangle(250, 150, 200, 200));
                }

                // Save the image (source is already bound to the file)
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
 * 1. When you need to generate a BMP file that visualizes layered data using semi‑transparent circles for a dashboard or report.
 * 2. When you want to programmatically create a background image with depth effects by drawing overlapping ellipses with different opacity levels in a C# application.
 * 3. When you have to produce a placeholder graphic for UI mockups where color‑coded circles indicate status zones and require adjustable transparency.
 * 4. When you are building a custom chart or heat‑map where each region is represented by a colored circle and the opacity conveys intensity, and you need to save it as BMP using Aspose.Imaging.
 * 5. When you need to automate the creation of test images for image‑processing algorithms that must contain overlapping shapes with varying alpha values.
 */
