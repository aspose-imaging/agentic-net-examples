using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                // Create a figure with a Bezier curve and an arc
                Figure figure = new Figure();

                // Bezier shape (4 points, closed)
                figure.AddShape(new BezierShape(
                    new PointF[]
                    {
                        new PointF(50f, 200f),
                        new PointF(150f, 50f),
                        new PointF(250f, 350f),
                        new PointF(350f, 150f)
                    },
                    true));

                // Arc shape
                figure.AddShape(new ArcShape(new RectangleF(100f, 100f, 200f, 200f), 0f, 180f));

                // Build the graphics path and flatten it
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);
                path.Flatten(); // Convert curves to line segments

                // Draw the flattened path onto the image
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                graphics.DrawPath(new Pen(Color.Blue, 2), path);

                // Save the result
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}