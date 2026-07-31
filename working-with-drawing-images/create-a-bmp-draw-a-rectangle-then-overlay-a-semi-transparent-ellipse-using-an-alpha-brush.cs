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
            // Output file path
            string outputPath = @"C:\temp\output.bmp";

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

                // Draw a blue rectangle
                Pen rectPen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(rectPen, new Rectangle(50, 50, 400, 400));

                // Draw a semi‑transparent red ellipse over the rectangle
                using (SolidBrush ellipseBrush = new SolidBrush(Color.Red))
                {
                    ellipseBrush.Opacity = 0.5f; // 50% opacity
                    graphics.FillEllipse(ellipseBrush, new Rectangle(100, 100, 300, 300));
                }

                // Save the image (output path already bound)
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
 * 1. When a developer needs to generate a BMP thumbnail with a highlighted region, they can draw a rectangle and overlay a semi‑transparent ellipse using Aspose.Imaging for .NET to indicate focus areas.
 * 2. When creating custom UI icons or badges in a Windows desktop application, the code can produce a 500×500 BMP with a blue border and a 50 % opacity red ellipse for visual emphasis.
 * 3. When preparing test images for computer‑vision algorithms that require known geometric shapes, this snippet creates a BMP containing a rectangle and a translucent ellipse to evaluate shape detection and opacity handling.
 * 4. When automating the production of printable labels that need a colored overlay, developers can use the code to draw a rectangle frame and a semi‑transparent ellipse on a BMP file before sending it to a printer.
 * 5. When building a reporting tool that adds watermark‑style graphics to BMP charts, the example shows how to overlay a semi‑transparent ellipse on top of a rectangular area to mark confidential sections.
 */