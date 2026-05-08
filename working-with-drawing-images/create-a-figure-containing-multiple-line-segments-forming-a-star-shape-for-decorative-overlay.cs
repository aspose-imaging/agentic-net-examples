using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hardcoded)
            string outputPath = @"c:\temp\star.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with file source bound to the output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path and a figure
                GraphicsPath graphicsPath = new GraphicsPath();
                Figure figure = new Figure();

                // Define star points (10-pointed star)
                PointF[] starPoints = new PointF[]
                {
                    new PointF(250f, 50f),
                    new PointF(300f, 200f),
                    new PointF(450f, 200f),
                    new PointF(325f, 300f),
                    new PointF(375f, 450f),
                    new PointF(250f, 350f),
                    new PointF(125f, 450f),
                    new PointF(175f, 300f),
                    new PointF(50f, 200f),
                    new PointF(200f, 200f)
                };

                // Add a closed polygon shape representing the star
                figure.AddShape(new PolygonShape(starPoints, true));

                // Add the figure to the graphics path
                graphicsPath.AddFigure(figure);

                // Draw the path with a black pen
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

                // Save the image (file is already bound to the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}