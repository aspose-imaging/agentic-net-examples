// HOW-TO: Create Light Blue BMP With Overlapping Transparent Rectangles In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Clear the canvas to light blue
                graphics.Clear(Color.LightBlue);

                // First semi‑transparent red rectangle
                using (SolidBrush brush1 = new SolidBrush(Color.Red))
                {
                    brush1.Opacity = 0.5f; // 50% opacity
                    graphics.FillRectangle(brush1, new Rectangle(50, 50, 200, 150));
                }

                // Second semi‑transparent green rectangle overlapping the first
                using (SolidBrush brush2 = new SolidBrush(Color.Green))
                {
                    brush2.Opacity = 0.5f;
                    graphics.FillRectangle(brush2, new Rectangle(150, 100, 200, 150));
                }

                // Third semi‑transparent blue rectangle overlapping the others
                using (SolidBrush brush3 = new SolidBrush(Color.Blue))
                {
                    brush3.Opacity = 0.5f;
                    graphics.FillRectangle(brush3, new Rectangle(250, 150, 200, 150));
                }

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
 * 1. When you need to generate a BMP placeholder image with a colored background and semi‑transparent overlays for UI mockups or documentation.
 * 2. When creating custom map legends where overlapping colored shapes indicate different data layers and require opacity blending.
 * 3. When producing test images for verifying image‑processing pipelines that must handle BMP files with simulated transparency.
 * 4. When building a simple graphics editor that lets users add translucent shapes on a solid‑color canvas using Aspose.Imaging in C#.
 * 5. When automating the creation of watermark‑style graphics that combine multiple colored rectangles over a uniform background for branding purposes.
 */
