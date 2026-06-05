using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output directory
            string outputDir = @"C:\Temp\Shapes";
            Directory.CreateDirectory(outputDir);

            // List of shapes to draw
            var shapes = new List<string> { "Rectangle", "Ellipse", "Line", "Polygon", "Pie" };
            int width = 200;
            int height = 200;

            foreach (var shapeName in shapes)
            {
                string outputPath = Path.Combine(outputDir, shapeName + ".bmp");
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with bound file source
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 24;
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                // Create image canvas
                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    // Initialize graphics
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    // Common pen
                    Pen pen = new Pen(Color.Black, 2);

                    // Draw specific shape
                    switch (shapeName)
                    {
                        case "Rectangle":
                            graphics.DrawRectangle(pen, new Rectangle(20, 20, 160, 160));
                            break;
                        case "Ellipse":
                            graphics.DrawEllipse(pen, new Rectangle(20, 20, 160, 160));
                            break;
                        case "Line":
                            graphics.DrawLine(pen, new Point(20, 20), new Point(180, 180));
                            break;
                        case "Polygon":
                            Point[] polygonPoints = new Point[]
                            {
                                new Point(100, 20),
                                new Point(180, 180),
                                new Point(20, 180)
                            };
                            graphics.DrawPolygon(pen, polygonPoints);
                            break;
                        case "Pie":
                            graphics.DrawPie(pen, new Rectangle(20, 20, 160, 160), 0, 120);
                            break;
                    }

                    // Save the bound image
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
 * 1. When a developer needs to generate a set of BMP icons representing basic geometric shapes for a UI toolkit, they can use this code to batch create 200×200 images of rectangles, ellipses, lines, polygons, and pies.
 * 2. When an automated testing framework requires sample bitmap files with known drawing primitives to validate image comparison algorithms, this snippet can quickly produce the required BMP files.
 * 3. When a documentation generator must embed example graphics of common shapes in PDF or HTML guides, the code can produce the BMP assets in a single folder.
 * 4. When a game developer wants to pre‑render simple shape textures for sprites or collision masks without using external design tools, the batch creation of BMP files simplifies the asset pipeline.
 * 5. When a data‑visualization service needs placeholder images for chart legends or diagram elements, this program can generate the necessary BMP files on demand.
 */