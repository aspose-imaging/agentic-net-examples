using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
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
        using (Image image = Image.Load(inputPath))
        {
            // Create a Graphics instance for drawing
            Graphics graphics = new Graphics(image);

            // Define pen styling (red color, 5-pixel width)
            Pen pen = new Pen(Color.Red, 5);

            // Define ellipse bounds
            RectangleF ellipseRect = new RectangleF(50f, 50f, 200f, 150f);

            // Draw the ellipse onto the image
            graphics.DrawEllipse(pen, ellipseRect);

            // Save the modified image, preserving JPEG format
            image.Save(outputPath);
        }
    }
}