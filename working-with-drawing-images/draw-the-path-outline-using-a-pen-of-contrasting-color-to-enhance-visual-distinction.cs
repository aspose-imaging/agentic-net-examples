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
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the input image
        using (RasterImage inputImage = (RasterImage)Image.Load(inputPath))
        {
            // Prepare PNG options with a bound output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new canvas with the same dimensions as the input
            using (Image canvas = Image.Create(pngOptions, inputImage.Width, inputImage.Height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Clear the canvas (optional, using a neutral background)
                graphics.Clear(Color.White);

                // Build a graphics path
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Example shape: a rectangle covering part of the image
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, inputImage.Width - 100f, inputImage.Height - 100f)));

                // Add the figure to the path
                path.AddFigure(figure);

                // Draw the path outline with a contrasting pen (red color, 3-pixel width)
                Pen outlinePen = new Pen(Color.Red, 3);
                graphics.DrawPath(outlinePen, path);

                // Save the canvas to the bound output file
                canvas.Save();
            }
        }
    }
}