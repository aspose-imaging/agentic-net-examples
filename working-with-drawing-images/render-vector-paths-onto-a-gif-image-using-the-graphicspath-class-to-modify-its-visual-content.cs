using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Use the first frame as the active drawing surface
            if (gif.PageCount > 0)
            {
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];
            }

            // Create a GraphicsPath with a rectangle and an ellipse
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 200f, 150f)));
            figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 100f, 100f)));
            path.AddFigure(figure);

            // Draw the path onto the active frame
            Graphics graphics = new Graphics(gif.ActiveFrame);
            Pen pen = new Pen(Color.Blue, 3);
            graphics.DrawPath(pen, path);

            // Save the modified GIF using GifOptions
            GifOptions options = new GifOptions();
            gif.Save(outputPath, options);
        }
    }
}