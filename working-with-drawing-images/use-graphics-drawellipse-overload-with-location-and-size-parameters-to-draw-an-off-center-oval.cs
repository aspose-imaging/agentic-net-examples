using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
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

            // Optional: clear the surface with a background color
            graphics.Clear(Color.White);

            // Define a pen for the ellipse
            Pen pen = new Pen(Color.Blue, 3);

            // Draw an off‑center oval using location (x, y) and size (width, height)
            // This ellipse's bounding rectangle starts at (100, 50) with width 200 and height 100
            graphics.DrawEllipse(pen, 100f, 50f, 200f, 100f);

            // Save the modified image to the output path
            image.Save(outputPath);
        }
    }
}