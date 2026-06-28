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
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a bound source for the BMP image
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = source;

            // Define canvas size
            int canvasWidth = 400;
            int canvasHeight = 300;

            // Create the BMP image (bound to the file)
            using (Image image = Image.Create(bmpOptions, canvasWidth, canvasHeight))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas to light blue
                graphics.Clear(Color.FromArgb(255, 173, 216, 230));

                // First semi‑transparent rectangle (red)
                using (SolidBrush brush1 = new SolidBrush())
                {
                    brush1.Color = Color.FromArgb(128, 255, 0, 0); // 50% transparent red
                    brush1.Opacity = 50; // Opacity in percent
                    graphics.FillRectangle(brush1, new Rectangle(50, 50, 200, 150));
                }

                // Second semi‑transparent rectangle (blue) overlapping the first
                using (SolidBrush brush2 = new SolidBrush())
                {
                    brush2.Color = Color.FromArgb(128, 0, 0, 255); // 50% transparent blue
                    brush2.Opacity = 50; // Opacity in percent
                    graphics.FillRectangle(brush2, new Rectangle(150, 100, 200, 150));
                }

                // Save the bound image to the specified file
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
 * 1. When generating a BMP thumbnail for a product catalog, a developer can clear the background to light blue and overlay semi‑transparent red and blue rectangles to highlight promotional zones.
 * 2. When creating a simple UI mockup in a C# desktop application, the code can be used to set a light‑blue canvas and draw overlapping translucent rectangles to represent buttons or panels.
 * 3. When producing test images for image‑processing algorithms, a developer may need a BMP file with a known background color and semi‑transparent shapes to verify blending and opacity handling.
 * 4. When building a reporting tool that exports charts as BMP files, the code can clear the image to a pastel background and draw overlapping translucent rectangles to illustrate data ranges or thresholds.
 * 5. When preparing instructional graphics for documentation, a developer can use this snippet to create a BMP illustration with a light‑blue background and overlapping semi‑transparent rectangles to demonstrate layering concepts.
 */