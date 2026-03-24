using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source bound to the output path
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new PNG image with the specified dimensions
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a white background
            graphics.Clear(Color.White);

            // Define a black pen with a thickness of 2 pixels
            Pen pen = new Pen(Color.Black, 2);

            // Draw straight lines to form a rectangle
            graphics.DrawLine(pen, new Point(50, 50), new Point(450, 50));
            graphics.DrawLine(pen, new Point(450, 50), new Point(450, 450));
            graphics.DrawLine(pen, new Point(450, 450), new Point(50, 450));
            graphics.DrawLine(pen, new Point(50, 450), new Point(50, 50));

            // Save the image (the file is already bound via FileCreateSource)
            image.Save();
        }
    }
}