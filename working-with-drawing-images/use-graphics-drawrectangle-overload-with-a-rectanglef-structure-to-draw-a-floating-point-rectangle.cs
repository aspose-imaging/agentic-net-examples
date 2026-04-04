using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing image
        using (Image image = Image.Load(inputPath))
        {
            // Create a Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Define a Pen (color and width)
            Pen pen = new Pen(Color.Red, 3);

            // Define a floating‑point rectangle (x, y, width, height)
            RectangleF rect = new RectangleF(50f, 50f, 200f, 150f);

            // Draw the rectangle using the RectangleF overload
            graphics.DrawRectangle(pen, rect);

            // Save the modified image to the output path
            image.Save(outputPath);
        }
    }
}