using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

// Create a PNG image of size 600x600
using (FileStream stream = new FileStream(@"output.png", FileMode.Create))
{
    // Set PNG options and associate the stream as the source
    PngOptions pngOptions = new PngOptions();
    pngOptions.Source = new StreamSource(stream);

    // Create the image
    using (Image image = Image.Create(pngOptions, 600, 600))
    {
        // Initialize graphics object for drawing
        Graphics graphics = new Graphics(image);
        graphics.Clear(Color.Wheat);

        // Prepare figures with various shapes
        Figure rectFigure = new Figure();
        rectFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

        Figure ellipseFigure = new Figure();
        ellipseFigure.AddShape(new EllipseShape(new RectangleF(300f, 50f, 200f, 150f)));

        Figure pieFigure = new Figure();
        pieFigure.AddShape(new PieShape(new RectangleF(150f, 250f, 300f, 200f), 0f, 120f));

        Figure arcFigure = new Figure();
        arcFigure.AddShape(new ArcShape(new RectangleF(50f, 400f, 200f, 150f), 45f, 180f));

        Figure polygonFigure = new Figure();
        polygonFigure.AddShape(new PolygonShape(
            new[]
            {
                new PointF(400f, 400f),
                new PointF(500f, 450f),
                new PointF(450f, 550f),
                new PointF(350f, 500f)
            }, true));

        // Add all figures to a GraphicsPath via an array
        GraphicsPath path = new GraphicsPath();
        path.AddFigures(new[] { rectFigure, ellipseFigure, pieFigure, arcFigure, polygonFigure });

        // Draw the path using a black pen
        graphics.DrawPath(new Pen(Color.Black, 2), path);

        // Save the image (writes to the stream)
        image.Save();
    }
}