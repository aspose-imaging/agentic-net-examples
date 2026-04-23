using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "pattern.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the pattern image to be used by the TextureBrush
        using (Aspose.Imaging.Image patternImage = Aspose.Imaging.Image.Load(inputPath))
        {
            // Create a PNG canvas
            var pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);
            int canvasWidth = 500;
            int canvasHeight = 500;

            using (Aspose.Imaging.Image canvas = Aspose.Imaging.Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Initialize graphics for the canvas
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Build a GraphicsPath (a simple rectangle)
                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 400f, 400f)));
                path.AddFigure(figure);

                // Create a TextureBrush using the pattern image
                using (TextureBrush textureBrush = new TextureBrush(
                    patternImage,
                    new Aspose.Imaging.Rectangle(0, 0, patternImage.Width, patternImage.Height)))
                {
                    // Fill the path with the texture brush
                    graphics.FillPath(textureBrush, path);
                }

                // Save the canvas (output file is already bound via FileCreateSource)
                canvas.Save();
            }
        }
    }
}