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
        // Hardcoded output path for the BMP logo
        string outputPath = @"C:\temp\custom_logo.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Configure BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 400x400 image canvas
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Draw outer rectangle border
                graphics.DrawRectangle(new Pen(Color.Black, 5), new Rectangle(10, 10, 380, 380));

                // Fill inner rectangle with light blue
                using (SolidBrush rectBrush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillRectangle(rectBrush, new Rectangle(50, 50, 300, 300));
                }

                // Draw a dark blue ellipse outline
                graphics.DrawEllipse(new Pen(Color.DarkBlue, 3), new Rectangle(100, 100, 200, 200));

                // Fill a smaller yellow ellipse inside
                using (SolidBrush ellipseBrush = new SolidBrush(Color.Yellow))
                {
                    graphics.FillEllipse(ellipseBrush, new Rectangle(150, 150, 100, 100));
                }

                // Save the image (bound to the file source)
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
 * 1. When a developer needs to generate a simple company logo as a 24‑bit BMP file using C# and Aspose.Imaging by programmatically drawing rectangles and ellipses.
 * 2. When an application must create placeholder images with geometric shapes for testing image processing pipelines that expect BMP format and Graphics drawing operations.
 * 3. When a reporting tool requires dynamic generation of badge icons with colored borders and inner shapes without relying on external image assets, using SolidBrush and Pen objects.
 * 4. When a desktop utility needs to export custom graphics, such as a stylized emblem, directly to a file system path with FileCreateSource and BmpOptions.
 * 5. When a developer wants to automate the production of printable symbols or watermarks composed of rectangles and ellipses for batch processing in .NET.
 */