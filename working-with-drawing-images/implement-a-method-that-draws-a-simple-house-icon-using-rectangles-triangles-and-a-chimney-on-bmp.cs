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
            string outputPath = @"C:\temp\house.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // BMP options with 24 bits per pixel
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 200x200 image
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.White);

                // Pens for outlines
                Pen blackPen = new Pen(Color.Black, 2);

                // Brushes for fills
                using (SolidBrush houseBrush = new SolidBrush())
                {
                    houseBrush.Color = Color.LightGray;
                    houseBrush.Opacity = 100;

                    // Draw house body
                    graphics.FillRectangle(houseBrush, new Rectangle(50, 80, 100, 80));
                    graphics.DrawRectangle(blackPen, new Rectangle(50, 80, 100, 80));
                }

                using (SolidBrush roofBrush = new SolidBrush())
                {
                    roofBrush.Color = Color.DarkRed;
                    roofBrush.Opacity = 100;

                    // Roof triangle points
                    Point[] roofPoints = new Point[]
                    {
                        new Point(50, 80),
                        new Point(150, 80),
                        new Point(100, 30)
                    };

                    // Fill and draw roof
                    graphics.FillPolygon(roofBrush, roofPoints);
                    graphics.DrawPolygon(blackPen, roofPoints);
                }

                using (SolidBrush chimneyBrush = new SolidBrush())
                {
                    chimneyBrush.Color = Color.Gray;
                    chimneyBrush.Opacity = 100;

                    // Chimney rectangle
                    graphics.FillRectangle(chimneyBrush, new Rectangle(120, 30, 20, 30));
                    graphics.DrawRectangle(blackPen, new Rectangle(120, 30, 20, 30));
                }

                // Save the image (file is already bound to the source)
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
 * 1. When a developer needs to generate a lightweight 24‑bit BMP icon of a house for a Windows desktop application's toolbar using Aspose.Imaging's Graphics API.
 * 2. When an automated reporting system must embed a simple house illustration into BMP files to visually indicate property status in batch‑processed documents.
 * 3. When a game developer wants to create placeholder building sprites on the fly in C# without external image assets, leveraging Aspose.Imaging's FillRectangle and FillPolygon methods.
 * 4. When a real‑estate web service generates thumbnail BMP images of property icons on the server side for quick preview in email notifications.
 * 5. When a testing framework requires programmatically drawing basic shapes like a house with a chimney to validate image rendering pipelines and BMP file output in CI pipelines.
 */