using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hardcoded)
        string outputPath = @"C:\temp\green_square.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source bound to the output path
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 200x200 image canvas
        using (Image image = Image.Create(pngOptions, 200, 200))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Create a green pen with a thickness of 3 pixels
            Pen pen = new Pen(Color.Green, 3);

            // Outline a square at (50,50) with width and height of 100 pixels
            graphics.DrawRectangle(pen, 50, 50, 100, 100);

            // Save the image (output path is already bound)
            image.Save();
        }
    }
}