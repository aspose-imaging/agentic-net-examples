using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output file path (hardcoded)
        string outputPath = @"C:\Temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas
        using (Image image = Image.Create(bmpOptions, 200, 100))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Draw a black line
            graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 20), new Point(100, 20));

            // Scale horizontally by a factor of 2 (double length)
            graphics.ScaleTransform(2.0f, 1.0f);

            // Draw a red line after scaling (will appear twice as long)
            graphics.DrawLine(new Pen(Color.Red, 2), new Point(10, 50), new Point(100, 50));

            // Save the image (file is already bound to the output path)
            image.Save();
        }
    }
}