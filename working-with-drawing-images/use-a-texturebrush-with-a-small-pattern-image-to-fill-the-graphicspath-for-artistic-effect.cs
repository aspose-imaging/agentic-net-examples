using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input pattern image and output image paths
        string inputPath = "pattern.png";
        string outputPath = "output.png";

        // Verify that the pattern image exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the pattern image to be used by the TextureBrush
        using (Image patternImage = Image.Load(inputPath))
        {
            // Define canvas size
            int canvasWidth = 800;
            int canvasHeight = 600;

            // Create PNG options with a FileCreateSource bound to the output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create the canvas image
            using (Image canvas = Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Create a Graphics instance for drawing
                Graphics graphics = new Graphics(canvas);

                // Clear the canvas background
                graphics.Clear(Color.White);

                // Create a TextureBrush using the loaded pattern image
                // The destination rectangle defines the area of the pattern tile
                using (TextureBrush textureBrush = new TextureBrush(patternImage, new Rectangle(0, 0, patternImage.Width, patternImage.Height)))
                {
                    // Build a GraphicsPath with a single rectangular figure covering the canvas
                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(0f, 0f, canvasWidth, canvasHeight)));
                    path.AddFigure(figure);

                    // Fill the path with the texture brush
                    graphics.FillPath(textureBrush, path);
                }

                // Save the canvas image (output file is already bound via FileCreateSource)
                canvas.Save();
            }
        }
    }
}