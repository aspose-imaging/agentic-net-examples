using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hardcoded)
        string outputPath = @"C:\temp\rectangle.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas (400x300)
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 400, 300))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Clear the canvas with white background
            graphics.Clear(Aspose.Imaging.Color.White);

            // Define a blue pen with thickness 5
            Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5);

            // Define rectangle position (x=50, y=50) and size (width=200, height=150)
            Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(50, 50, 200, 150);

            // Draw the rectangle onto the image
            graphics.DrawRectangle(pen, rect);

            // Save the image (output is already bound to the file)
            image.Save();
        }
    }
}