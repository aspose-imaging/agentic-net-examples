using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tiff";
        string outputPath = @"C:\temp\output.tiff";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image from the input path
        using (Image image = Image.Load(inputPath))
        {
            // Initialize Graphics for the loaded image
            Graphics graphics = new Graphics(image);

            // Create a new GraphicsPath instance
            GraphicsPath graphicsPath = new GraphicsPath();

            // Create a figure and add a rectangle shape to it
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 200f, 200f)));

            // Add the figure to the GraphicsPath
            graphicsPath.AddFigure(figure);

            // Draw the path onto the image using a blue pen
            graphics.DrawPath(new Pen(Color.Blue, 2), graphicsPath);

            // Save the modified image to the output path
            image.Save(outputPath);
        }
    }
}