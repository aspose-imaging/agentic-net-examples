using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\polygon_output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new image (500x500 pixels)
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for the image
            Graphics graphics = new Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.Wheat);

            // Define five vertices for the closed polygon
            PointF[] vertices = new PointF[]
            {
                new PointF(100, 50),
                new PointF(200, 30),
                new PointF(300, 100),
                new PointF(250, 200),
                new PointF(150, 180)
            };

            // Create a closed PolygonShape
            PolygonShape polygon = new PolygonShape(vertices, true);

            // Create a Figure and add the polygon shape
            Figure figure = new Figure();
            figure.AddShape(polygon);

            // Add the Figure to a GraphicsPath
            GraphicsPath path = new GraphicsPath();
            path.AddFigure(figure);

            // Draw the path with a black pen
            graphics.DrawPath(new Pen(Aspose.Imaging.Color.Black, 2), path);

            // Save the image (output path already defined in the source)
            image.Save();
        }
    }
}