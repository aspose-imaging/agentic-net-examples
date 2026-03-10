using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = @"c:\temp\GraphicsPathExample.png";

        // Configure PNG options and set the file source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 500x500 image
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Fill background with a light gray color
            graphics.Clear(Color.LightGray);

            // Create a new graphics path
            GraphicsPath path = new GraphicsPath();

            // First figure: rectangle and ellipse
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            figure1.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 200f)));

            // Second figure: arc and closed polygon
            Figure figure2 = new Figure();
            figure2.AddShape(new ArcShape(new RectangleF(300f, 50f, 150f, 150f), 0f, 270f));
            figure2.AddShape(new PolygonShape(
                new[]
                {
                    new PointF(300f, 300f),
                    new PointF(350f, 350f),
                    new PointF(400f, 300f),
                    new PointF(350f, 250f)
                },
                true));

            // Add both figures to the graphics path
            path.AddFigures(new[] { figure1, figure2 });

            // Draw the path using a blue pen with thickness 3
            graphics.DrawPath(new Pen(Color.Blue, 3), path);

            // Save the image to the specified file
            image.Save();
        }
    }
}