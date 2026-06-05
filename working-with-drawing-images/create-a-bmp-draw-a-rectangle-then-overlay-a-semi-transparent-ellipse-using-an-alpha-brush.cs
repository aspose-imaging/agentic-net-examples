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
            // Hardcoded output path
            string outputPath = @"c:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Draw a blue rectangle outline
                Pen rectPen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(rectPen, new Rectangle(50, 50, 400, 400));

                // Overlay a semi‑transparent red ellipse
                using (SolidBrush ellipseBrush = new SolidBrush())
                {
                    ellipseBrush.Color = Color.Red;
                    ellipseBrush.Opacity = 0.5f; // 50% opacity (0 = fully visible, 1 = fully opaque)
                    graphics.FillEllipse(ellipseBrush, new Rectangle(100, 100, 300, 300));
                }

                // Save the image (FileCreateSource binds the output file)
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
 * 1. When a developer needs to generate a BMP thumbnail with a highlighted region, such as drawing a blue border rectangle and a semi‑transparent red ellipse to indicate a focus area in a Windows desktop application.
 * 2. When creating a printable report that includes a 500×500 BMP diagram where a rectangle outlines a section and an overlay ellipse with 50 % opacity is used to illustrate overlapping data zones.
 * 3. When building a custom UI control that dynamically renders BMP assets with vector shapes, using Aspose.Imaging’s Graphics API to draw a rectangle and an alpha‑blended ellipse for visual feedback.
 * 4. When automating the production of watermark‑style graphics for batch‑processed images, employing a blue rectangle frame and a semi‑transparent red ellipse to mark regions of interest before saving as BMP.
 * 5. When developing a diagnostic tool that visualizes sensor coverage on a BMP map by drawing a rectangular boundary and a translucent elliptical range using C# and Aspose.Imaging brushes.
 */