using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing image
        using (Image image = Image.Load(inputPath))
        {
            // Create a Graphics instance for drawing
            Graphics graphics = new Graphics(image);

            // Define the arc parameters
            // Example: center at (150,150), radius 100 => bounding rectangle (50,50,200,200)
            // Start angle 0 degrees, sweep angle 180 degrees
            Pen pen = new Pen(Color.Red, 3);
            Rectangle rect = new Rectangle(50, 50, 200, 200);
            float startAngle = 0f;
            float sweepAngle = 180f;

            // Draw the arc onto the image
            graphics.DrawArc(pen, rect, startAngle, sweepAngle);

            // Save the modified image
            image.Save(outputPath);
        }
    }
}