// HOW-TO: Create Multiple BMP Images with Different Shapes Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = "output";
            string[] shapes = { "Line", "Rectangle", "Ellipse", "Polygon", "Bezier" };
            int width = 200;
            int height = 200;

            foreach (var shape in shapes)
            {
                string outputPath = Path.Combine(outputDir, shape + ".bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    Pen pen = new Pen(Color.Black);
                    switch (shape)
                    {
                        case "Line":
                            graphics.DrawLine(pen, 10, 10, 190, 190);
                            break;
                        case "Rectangle":
                            graphics.DrawRectangle(pen, 20, 20, 160, 120);
                            break;
                        case "Ellipse":
                            graphics.DrawEllipse(pen, 20, 20, 160, 120);
                            break;
                        case "Polygon":
                            PointF[] polygonPoints = new PointF[]
                            {
                                new PointF(100, 10),
                                new PointF(190, 190),
                                new PointF(10, 190)
                            };
                            graphics.DrawPolygon(pen, polygonPoints);
                            break;
                        case "Bezier":
                            graphics.DrawBezier(pen,
                                new PointF(10, 190),
                                new PointF(50, 10),
                                new PointF(150, 10),
                                new PointF(190, 190));
                            break;
                    }

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
 * 1. When you need to generate a set of BMP icons that each display a distinct geometric shape for a UI library or testing suite.
 * 2. When creating sample image assets for documentation or tutorials that require separate shape illustrations in BMP format using C#.
 * 3. When automating the production of placeholder graphics for a game level editor, where each BMP file represents a different collision shape.
 * 4. When building a batch process that outputs BMP files for a hardware device that only accepts monochrome shape patterns.
 * 5. When validating image‑processing pipelines by supplying known BMP files containing lines, rectangles, ellipses, polygons, and Bezier curves.
 */
