using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Prepare TIFF options and associate a stream source for output
        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        using (var stream = new FileStream("GraphicsPathOutput.tiff", FileMode.Create))
        {
            tiffOptions.Source = new StreamSource(stream);

            // Create a new 600x600 TIFF image
            using (var image = Image.Create(tiffOptions, 600, 600) as TiffImage)
            {
                // Initialize graphics and clear background
                var graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);

                // Build a complete GraphicsPath with multiple figures and shapes
                var graphicsPath = new GraphicsPath();

                // Figure 1: rectangle, ellipse and pie shape
                var figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                figure1.AddShape(new EllipseShape(new RectangleF(300f, 50f, 200f, 150f)));
                figure1.AddShape(new PieShape(
                    new RectangleF(new PointF(200f, 250f), new SizeF(200f, 200f)),
                    0f, 120f));
                graphicsPath.AddFigure(figure1);

                // Figure 2: custom Bezier shape
                var figure2 = new Figure();
                figure2.AddShape(CreateBezierShape(
                    100f, 400f,
                    200f, 300f,
                    300f, 500f,
                    400f, 400f));
                graphicsPath.AddFigure(figure2);

                // Render the path onto the image with a blue pen
                graphics.DrawPath(new Pen(Color.Blue, 5), graphicsPath);

                // Store the drawn path as a PathResource inside the TIFF (optional)
                var pathResources = PathResourceConverter.FromGraphicsPath(graphicsPath, image.Size);
                image.ActiveFrame.PathResources = new List<PathResource>(pathResources);

                // Save the image (writes to the associated stream)
                image.Save();
            }
        }
    }

    // Helper: creates a BezierShape from a list of coordinates
    private static BezierShape CreateBezierShape(params float[] coordinates)
    {
        var points = CoordinatesToBezierPoints(coordinates);
        return new BezierShape(points, true);
    }

    // Helper: converts float coordinate pairs to PointF array,
    // duplicating each point three times as required by Bezier knots
    private static PointF[] CoordinatesToBezierPoints(float[] coordinates)
    {
        var list = new List<PointF>();
        for (int i = 0; i < coordinates.Length; i += 2)
        {
            var pt = new PointF(coordinates[i], coordinates[i + 1]);
            list.Add(pt);
            list.Add(pt);
            list.Add(pt);
        }
        return list.ToArray();
    }
}