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
        // Hardcoded input and output paths
        string inputPath = "vector.svg"; // placeholder, not used in this example
        string outputPath = "output.png";

        // Verify input file existence (if it were used)
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Create a source bound to the output file
        Source source = new FileCreateSource(outputPath, false);

        // Set up PNG options with the bound source
        PngOptions pngOptions = new PngOptions { Source = source };

        // Define canvas size
        int canvasWidth = 800;
        int canvasHeight = 600;

        // Create the PNG canvas (bound image)
        using (Image canvas = Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            // Build a graphics path with vector shapes
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 300f, 200f)));
            // Ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 150f)));
            // Pie shape
            figure.AddShape(new PieShape(new RectangleF(200f, 200f, 250f, 250f), 0f, 120f));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path onto the canvas
            Pen pen = new Pen(Color.Black, 3);
            graphics.DrawPath(pen, path);

            // Save the bound image
            canvas.Save();
        }
    }
}