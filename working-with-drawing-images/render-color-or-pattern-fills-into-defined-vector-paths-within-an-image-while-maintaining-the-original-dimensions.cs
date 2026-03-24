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

        // Load the input image to obtain its dimensions
        using (Aspose.Imaging.Image inputImage = Aspose.Imaging.Image.Load(inputPath))
        {
            int width = inputImage.Width;
            int height = inputImage.Height;

            // Create a new PNG image with the same dimensions
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, width, height))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Define a graphics path with a rectangle and an ellipse
                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

                // Rectangle shape
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 200f, 150f)));
                // Ellipse shape
                figure.AddShape(new Aspose.Imaging.Shapes.EllipseShape(new Aspose.Imaging.RectangleF(300f, 100f, 150f, 150f)));

                // Add the figure to the path
                path.AddFigure(figure);

                // Fill the path with a solid blue brush
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    graphics.FillPath(brush, path);
                }

                // Save the image (output is already bound to the file)
                image.Save();
            }
        }
    }
}