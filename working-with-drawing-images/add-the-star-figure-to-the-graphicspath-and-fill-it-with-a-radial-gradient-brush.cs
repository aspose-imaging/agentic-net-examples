using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\star_output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PNG image options
        PngOptions pngOptions = new PngOptions();

        // Create a new raster image (500x500)
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics object
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Define points of a 5‑pointed star
            PointF[] starPoints = new PointF[]
            {
                new PointF(250, 50),
                new PointF(280, 180),
                new PointF(400, 180),
                new PointF(300, 250),
                new PointF(340, 380),
                new PointF(250, 300),
                new PointF(160, 380),
                new PointF(200, 250),
                new PointF(100, 180),
                new PointF(220, 180)
            };

            // Create a figure representing the star
            Figure starFigure = new Figure();
            starFigure.IsClosed = true;
            starFigure.AddShape(new PolygonShape(starPoints));

            // Add the figure to a graphics path
            GraphicsPath starPath = new GraphicsPath();
            starPath.AddFigure(starFigure);

            // Create a radial gradient brush based on the star points
            PathGradientBrush gradientBrush = new PathGradientBrush(starPoints);
            gradientBrush.CenterColor = Color.Yellow;
            gradientBrush.SurroundColors = new Color[] { Color.Orange };

            // Fill the star with the gradient brush
            graphics.FillPath(gradientBrush, starPath);

            // Save the image to the specified path
            image.Save(outputPath);
        }
    }
}