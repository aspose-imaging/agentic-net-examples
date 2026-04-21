using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the existing image
        using (Image image = Image.Load(inputPath))
        {
            // Create a Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Outline a green square using the (int x, int y, int width, int height) overload
            // Square positioned at (50,50) with side length 200
            Pen greenPen = new Pen(Color.Green, 2);
            graphics.DrawRectangle(greenPen, 50, 50, 200, 200);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the modified image
            image.Save(outputPath);
        }
    }
}