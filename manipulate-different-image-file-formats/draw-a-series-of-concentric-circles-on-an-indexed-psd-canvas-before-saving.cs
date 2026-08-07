// HOW-TO: Create Concentric Circles on Indexed PSD Canvas in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output PSD file path (hard‑coded)
            string outputPath = @"C:\temp\concentric_circles.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PSD options for an indexed color mode
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;

            // Define a simple palette (black & white) for the indexed image
            psdOptions.Palette = new ColorPalette(
                new Color[] { Color.Black, Color.White });

            // Create a new PSD image (500x500 pixels)
            using (Image image = Image.Create(psdOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Center of the canvas
                int centerX = image.Width / 2;
                int centerY = image.Height / 2;

                // Maximum radius for the outermost circle
                int maxRadius = Math.Min(centerX, centerY) - 10;

                // Draw concentric circles with decreasing radius
                for (int radius = maxRadius; radius > 0; radius -= 20)
                {
                    // Rectangle that bounds the circle
                    Rectangle bounds = new Rectangle(
                        centerX - radius,
                        centerY - radius,
                        radius * 2,
                        radius * 2);

                    // Draw the circle outline
                    graphics.DrawEllipse(new Pen(Color.Black, 2), bounds);
                }

                // Save the PSD image (output path already bound via FileCreateSource)
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
 * 1. When you need to generate a simple bullseye or target pattern directly inside a PSD file for later Photoshop editing.
 * 2. When you want to programmatically create a black‑and‑white indexed PSD thumbnail that keeps file size low for UI galleries.
 * 3. When you must produce geometric guides in a PSD so designers can overlay text, logos, or other assets with precise alignment.
 * 4. When you are building a batch process that adds diagnostic circles to scanned images stored as PSDs to indicate focus points.
 * 5. When you need to automate the creation of printable ruler or measurement graphics inside an indexed PSD for print workflows.
 */
