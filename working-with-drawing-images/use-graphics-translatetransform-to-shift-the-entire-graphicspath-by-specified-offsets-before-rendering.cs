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
        string inputPath = "input.png";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = "output.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Create a new PNG image canvas
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(pngOptions, 400, 400))
        {
            // Initialize graphics for the image
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Build a graphics path with a rectangle shape
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 100f, 100f)));
            path.AddFigure(figure);

            // Shift the entire path by the specified offsets
            graphics.TranslateTransform(100f, 50f);

            // Draw the translated path
            graphics.DrawPath(new Pen(Color.Blue, 2), path);

            // Save the image (FileCreateSource binds the output file)
            image.Save();
        }
    }
}