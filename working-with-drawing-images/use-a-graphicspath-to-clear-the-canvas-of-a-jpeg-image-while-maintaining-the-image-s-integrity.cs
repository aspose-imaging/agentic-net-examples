using System;
using System.IO;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Create a Graphics instance for the image
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Build a GraphicsPath that covers the entire canvas
            Aspose.Imaging.GraphicsPath graphicsPath = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(0f, 0f, image.Width, image.Height)));
            graphicsPath.AddFigure(figure);

            // Fill the path with white to clear the canvas
            using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.White))
            {
                graphics.FillPath(brush, graphicsPath);
            }

            // Save the cleared image
            image.Save(outputPath);
        }
    }
}