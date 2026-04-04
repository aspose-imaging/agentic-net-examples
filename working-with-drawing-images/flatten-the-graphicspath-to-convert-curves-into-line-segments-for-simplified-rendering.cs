using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the input image to obtain its dimensions
        using (Image inputImage = Image.Load(inputPath))
        {
            int width = inputImage.Width;
            int height = inputImage.Height;

            // Create a new PNG image canvas with the same size
            PngOptions pngOptions = new PngOptions();
            using (Image canvas = Image.Create(pngOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Build a GraphicsPath containing a Bezier curve
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new BezierShape(
                    new PointF[]
                    {
                        new PointF(50f, 200f),
                        new PointF(150f, 50f),
                        new PointF(250f, 350f),
                        new PointF(350f, 150f)
                    },
                    true));
                path.AddFigure(figure);

                // Flatten the path to convert curves into line segments
                path.Flatten();

                // Draw the flattened path
                graphics.DrawPath(new Pen(Color.Blue, 2), path);

                // Save the resulting image
                canvas.Save(outputPath, pngOptions);
            }
        }
    }
}