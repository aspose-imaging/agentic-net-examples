// HOW-TO: Draw a Cubic Bezier Curve on a PNG with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (PngOptions pngOptions = new PngOptions())
            {
                pngOptions.Source = new FileCreateSource(outputPath, false);

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 600, 400))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                    Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

                    Aspose.Imaging.PointF pt1 = new Aspose.Imaging.PointF(0, 0);
                    Aspose.Imaging.PointF pt2 = new Aspose.Imaging.PointF(200, 133);
                    Aspose.Imaging.PointF pt3 = new Aspose.Imaging.PointF(400, 166);
                    Aspose.Imaging.PointF pt4 = new Aspose.Imaging.PointF(600, 400);

                    BezierShape bezier = new BezierShape(new Aspose.Imaging.PointF[] { pt1, pt2, pt3, pt4 });
                    figure.AddShape(bezier);
                    path.AddFigure(figure);

                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2);
                    graphics.DrawPath(pen, path);

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
 * 1. When you need to generate a vector‑based illustration such as a smooth curve and export it as a PNG for web or UI assets.
 * 2. When you want to programmatically create custom chart lines or signature strokes in a .NET application using Aspose.Imaging.
 * 3. When you must overlay a precise cubic Bezier path onto an existing image for watermarking or diagram annotations.
 * 4. When you are building a design‑tool feature that lets users define control points and renders the resulting curve directly to a raster file.
 * 5. When you require automated generation of scalable curve graphics for reports or PDFs without relying on external drawing libraries.
 */
