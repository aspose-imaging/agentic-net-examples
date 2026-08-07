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
            // Output file path (hard‑coded)
            string outputPath = @"c:\temp\overlapping_circles.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options with a bound file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // First circle (red, 30% opacity)
                using (SolidBrush brush1 = new SolidBrush(Color.Red))
                {
                    brush1.Opacity = 0.3f;
                    graphics.FillEllipse(brush1, new Rectangle(50, 50, 200, 200));
                }

                // Second circle (green, 50% opacity) overlapping the first
                using (SolidBrush brush2 = new SolidBrush(Color.Green))
                {
                    brush2.Opacity = 0.5f;
                    graphics.FillEllipse(brush2, new Rectangle(150, 100, 200, 200));
                }

                // Third circle (blue, 70% opacity) overlapping the others
                using (SolidBrush brush3 = new SolidBrush(Color.Blue))
                {
                    brush3.Opacity = 0.7f;
                    graphics.FillEllipse(brush3, new Rectangle(250, 150, 200, 200));
                }

                // Save the image (file is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a BMP file that visualizes layered data points, such as overlapping geographic regions, using varying opacity to convey depth.
 * 2. When creating a simple placeholder image for UI testing where semi‑transparent circles illustrate how alpha blending works in C# with Aspose.Imaging.
 * 3. When producing a printable diagram in BMP format that demonstrates color mixing effects for educational material on additive color theory.
 * 4. When building a reporting tool that programmatically draws translucent markers on a map background to highlight areas of interest without external image assets.
 * 5. When automating the creation of icon‑style graphics where overlapping circles with different opacities simulate a 3‑D button effect in a Windows desktop application.
 */