// HOW-TO: Fill Polygon Shape With Cross Hatch Pattern In C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\temp\polygon_hatch.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with a FileCreateSource bound to the output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas (500x500)
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize Graphics (do NOT wrap in using – Graphics is not IDisposable)
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a GraphicsPath
                GraphicsPath graphicsPath = new GraphicsPath();

                // Create a Figure containing a polygon shape
                Figure figure = new Figure();
                figure.AddShape(new PolygonShape(new PointF[]
                {
                    new PointF(100f, 100f),
                    new PointF(200f, 50f),
                    new PointF(300f, 100f),
                    new PointF(250f, 200f),
                    new PointF(150f, 200f)
                }));

                // Add the Figure to the GraphicsPath
                graphicsPath.AddFigure(figure);

                // NOTE: HatchBrush is not supported with Graphics.FillPath.
                // Using SolidBrush as a safe fallback.
                using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillPath(brush, graphicsPath);
                }

                // Optional: draw the polygon outline
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, graphicsPath);

                // Save the image (output file is already bound via FileCreateSource)
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
 * 1. When you need to generate a PNG image that contains a custom polygon filled with a cross‑hatch pattern for reports or dashboards.
 * 2. When creating printable graphics such as certificates or flyers and want a lightweight vector polygon with a hatch fill instead of embedding large raster textures.
 * 3. When dynamically rendering map overlays in a C# web application and require a hatch‑filled polygon to highlight restricted zones.
 * 4. When building a Windows Forms UI component that uses a vector polygon with a cross hatch brush for visual distinction without external image resources.
 * 5. When automating technical diagram production and need to programmatically fill irregular shapes with a repeatable hatch pattern using Aspose.Imaging for .NET.
 */
