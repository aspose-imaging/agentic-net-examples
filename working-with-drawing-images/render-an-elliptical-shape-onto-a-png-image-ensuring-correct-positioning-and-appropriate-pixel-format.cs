using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define output path (hardcoded)
        string outputPath = @"C:\Temp\ellipse.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a FileCreateSource bound to the output path
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Define image dimensions
        int width = 400;
        int height = 300;

        // Create the PNG image canvas
        using (Image image = Image.Create(pngOptions, width, height))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a white background
            graphics.Clear(Color.White);

            // Define the ellipse bounds
            Rectangle ellipseRect = new Rectangle(50, 50, 300, 200);

            // Draw the ellipse with a blue pen of thickness 5
            Pen pen = new Pen(Color.Blue, 5);
            graphics.DrawEllipse(pen, ellipseRect);

            // Save the image (output path is already bound via FileCreateSource)
            image.Save();
        }
    }
}