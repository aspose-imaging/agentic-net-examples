using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Arc styling parameters
            Pen pen = new Pen(Color.Blue, 4);               // Blue pen with width 4
            Rectangle arcBounds = new Rectangle(100, 100, 300, 200); // Bounding rectangle
            int startAngle = 30;    // Starting angle in degrees
            int sweepAngle = 120;   // Sweep angle in degrees

            // Draw the arc onto the image
            graphics.DrawArc(pen, arcBounds, startAngle, sweepAngle);

            // Save the modified image to the output path
            image.Save(outputPath);
        }
    }
}