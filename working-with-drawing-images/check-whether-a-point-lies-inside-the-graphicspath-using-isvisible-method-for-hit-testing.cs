using System;
using System.IO;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Default input and output paths
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
        using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputStream))
        {
            // Create a Graphics instance for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Create a GraphicsPath and add a rectangle shape
            Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(10f, 10f, 200f, 200f)));
            path.AddFigure(figure);

            // Draw the path for visual reference
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), path);

            // Test a point for visibility inside the path
            float testX = 50f;
            float testY = 50f;
            bool isInside = path.IsVisible(testX, testY);
            Console.WriteLine($"Point ({testX}, {testY}) inside path: {isInside}");

            // Save the resulting image
            image.Save(outputPath);
        }
    }
}