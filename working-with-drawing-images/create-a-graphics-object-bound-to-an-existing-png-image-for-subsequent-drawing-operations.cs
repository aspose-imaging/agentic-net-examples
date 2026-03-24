using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"input.png";
        string outputPath = @"output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load existing PNG image
        using (PngImage png = new PngImage(inputPath))
        {
            // Create Graphics bound to the loaded image
            Graphics graphics = new Graphics(png);

            // Example drawing operations
            graphics.Clear(Color.Wheat);
            graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 10), new Point(200, 200));

            // Save the modified image
            png.Save(outputPath);
        }
    }
}