// HOW-TO: Create Indexed PSD with Concentric Circles Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\Temp\concentric_circles.psd";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            // Simple palette with a few colors
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                Color.Cyan,
                Color.Magenta
            });

            // Canvas size
            int width = 500;
            int height = 500;

            // Create the PSD image bound to the output file
            using (Image image = Image.Create(psdOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Center of the canvas
                int centerX = width / 2;
                int centerY = height / 2;

                // Draw concentric circles
                int numberOfCircles = 5;
                int step = 30;
                for (int i = 0; i < numberOfCircles; i++)
                {
                    int radius = (i + 1) * step;
                    Pen pen = new Pen(Color.Black, 2);
                    Rectangle rect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
                    graphics.DrawEllipse(pen, rect);
                }

                // Save the PSD (already bound to the file source)
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
 * 1. When you need to programmatically generate a PSD file with a limited color palette for use in a design workflow that requires indexed colors, such as preparing assets for older Photoshop versions.
 * 2. When you want to automate the creation of pattern overlays, like concentric circle guides, directly inside a PSD without manual drawing in Photoshop.
 * 3. When building a server‑side service that produces printable mock‑ups where the background is a PSD with vector‑style circles and a predefined palette for consistent branding colors.
 * 4. When creating test images for image‑processing pipelines that must read indexed PSD files and verify that shape rendering works correctly.
 * 5. When integrating Aspose.Imaging into a C# application to dynamically generate layered PSD files for game UI elements that use simple geometric shapes and a fixed set of colors.
 */
