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
            // Hardcoded output path for the indexed PSD file
            string outputPath = @"C:\Temp\ConcentricCircles.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image dimensions
            int width = 800;
            int height = 800;

            // Create PSD options for an indexed color mode
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;

            // Define a simple palette (e.g., 4 colors)
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Black,
                Color.Red,
                Color.Green,
                Color.Blue
            });

            // Create the PSD image bound to the output file
            using (Image image = Image.Create(psdOptions, width, height))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background with white color
                graphics.Clear(Color.White);

                // Center of the canvas
                int centerX = width / 2;
                int centerY = height / 2;

                // Draw concentric circles
                int maxRadius = Math.Min(width, height) / 2 - 10;
                int step = 40;
                for (int radius = maxRadius; radius > 0; radius -= step)
                {
                    // Choose a pen color cycling through the palette
                    Color penColor = radius % 4 == 0 ? Color.Black :
                                     radius % 4 == 1 ? Color.Red :
                                     radius % 4 == 2 ? Color.Green : Color.Blue;

                    Pen pen = new Pen(penColor, 3);
                    Rectangle rect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
                    graphics.DrawEllipse(pen, rect);
                }

                // Save the PSD image (output file already bound)
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
 * 1. When a developer needs to programmatically generate a PSD file with a simple indexed‑color palette for a printable pattern, such as a set of concentric circles used as a background in a brochure layout.
 * 2. When creating test assets for an image‑processing pipeline that must handle PSD files in indexed mode, drawing concentric circles helps verify that color indexing and pen drawing work correctly in Aspose.Imaging for .NET.
 * 3. When building a web‑to‑print service that automatically produces PSD templates with layered vector shapes, using C# to draw concentric circles on an indexed canvas provides a lightweight, color‑restricted design element.
 * 4. When producing educational graphics or tutorials that illustrate geometric concepts in a PSD file, developers can use the code to render concentric circles with a predefined palette for clear visual contrast.
 * 5. When generating thumbnail previews of PSD artwork that need to maintain a limited color set for performance, drawing concentric circles on an indexed PSD canvas offers a fast way to create sample images in C#.
 */