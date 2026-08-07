// HOW-TO: Create High Resolution PNG with Vector Shapes in C# (Aspose.Imaging for .NET)
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
            // Output path for the high‑resolution PNG image
            string outputPath = @"C:\temp\highres.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file stream bound to the output file
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Configure PNG options
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                // Create a 1000x1000 pixel image
                using (Image image = Image.Create(pngOptions, 1000, 1000))
                {
                    // Initialize Graphics for drawing
                    Graphics graphics = new Graphics(image);

                    // Clear background with light gray
                    graphics.Clear(Color.LightGray);

                    // Draw a thick black rectangle border
                    Pen rectPen = new Pen(Color.Black, 5);
                    graphics.DrawRectangle(rectPen, new Rectangle(50, 50, 900, 900));

                    // Fill an inner ellipse with blue using SolidBrush
                    using (SolidBrush ellipseBrush = new SolidBrush(Color.Blue))
                    {
                        graphics.FillEllipse(ellipseBrush, new Rectangle(200, 200, 600, 600));
                    }

                    // Draw a red diagonal line across the image
                    Pen linePen = new Pen(Color.Red, 3);
                    graphics.DrawLine(linePen, new Point(50, 50), new Point(950, 950));

                    // Draw a green polygon
                    Pen polyPen = new Pen(Color.Green, 4);
                    Point[] polyPoints = new Point[]
                    {
                        new Point(500, 150),
                        new Point(800, 400),
                        new Point(650, 800),
                        new Point(350, 800),
                        new Point(200, 400)
                    };
                    graphics.DrawPolygon(polyPen, polyPoints);

                    // Add a text label using a solid brush
                    using (SolidBrush textBrush = new SolidBrush(Color.DarkSlateGray))
                    {
                        Font textFont = new Font("Arial", 48);
                        graphics.DrawString("High‑Res Vector", textFont, textBrush, new PointF(250, 920));
                    }

                    // Save the image (stream is already bound to the file)
                    image.Save();
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
 * 1. When you need to generate a printable 300 DPI PNG badge with crisp vector graphics for a marketing campaign.
 * 2. When an application must programmatically create a diagram containing rectangles, ellipses, lines, and polygons for a reporting dashboard.
 * 3. When you want to export dynamically drawn shapes to a lossless PNG image for use in a PDF brochure without rasterization artifacts.
 * 4. When a server‑side service creates custom icons or thumbnails with precise dimensions and background colors for a web portal.
 * 5. When you need to automate the production of high‑resolution graphics for CNC laser cutting or embroidery patterns using C#.
 */
