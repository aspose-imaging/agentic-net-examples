using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define the list of image sizes (width, height)
            var sizes = new List<(int width, int height)>
            {
                (200, 200),
                (400, 300),
                (800, 600)
            };

            // Output directory for BMP files
            string outputDir = @"C:\Temp\BmpOutputs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            foreach (var size in sizes)
            {
                // Construct the output file path
                string outputPath = Path.Combine(outputDir, $"ellipse_{size.width}x{size.height}.bmp");

                // Create a bound source for the BMP image
                Source source = new FileCreateSource(outputPath, false);
                BmpOptions bmpOptions = new BmpOptions() { Source = source };

                // Create the BMP canvas bound to the file
                using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, size.width, size.height))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(canvas);

                    // Optional: clear background to white
                    graphics.Clear(Color.White);

                    // Create a red pen
                    Pen redPen = new Pen(Color.Red, 2);

                    // Define a rectangle that fills the canvas (centered ellipse)
                    Rectangle ellipseBounds = new Rectangle(0, 0, size.width, size.height);

                    // Draw the centered red ellipse
                    graphics.DrawEllipse(redPen, ellipseBounds);

                    // Save the bound image (no need to specify path again)
                    canvas.Save();
                }
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
 * 1. When generating placeholder graphics for UI mockups, a developer can batch‑create BMP files of various dimensions with a centered red ellipse to represent image slots.
 * 2. When preparing test assets for automated visual regression testing, the code can produce BMP images of different sizes containing a consistent red ellipse as a known reference shape.
 * 3. When building a batch image processing pipeline that needs to embed a simple watermark, developers can use this snippet to create BMP canvases of required resolutions with a centered red ellipse as the watermark.
 * 4. When creating sample data for a machine‑learning model that classifies shapes, the code can generate BMP images at multiple resolutions with a centered red ellipse to serve as training examples.
 * 5. When exporting diagram elements from a CAD or reporting tool, a developer can quickly generate BMP files of specified widths and heights with a centered red ellipse to illustrate circular components.
 */