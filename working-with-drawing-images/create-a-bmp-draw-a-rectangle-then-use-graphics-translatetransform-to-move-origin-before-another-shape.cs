using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new image with the specified size
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the background
            graphics.Clear(Aspose.Imaging.Color.Wheat);

            // Draw the first rectangle at (50,50) with size 200x150
            Pen firstPen = new Pen(Aspose.Imaging.Color.Black, 2);
            graphics.DrawRectangle(firstPen, new Aspose.Imaging.Rectangle(50, 50, 200, 150));

            // Translate the origin by (100,100)
            graphics.TranslateTransform(100, 100);

            // Draw a second rectangle at the new origin (0,0) with size 100x80
            Pen secondPen = new Pen(Aspose.Imaging.Color.Red, 2);
            graphics.DrawRectangle(secondPen, new Aspose.Imaging.Rectangle(0, 0, 100, 80));

            // Save the image to the file specified in bmpOptions.Source
            image.Save();
        }
    }
}