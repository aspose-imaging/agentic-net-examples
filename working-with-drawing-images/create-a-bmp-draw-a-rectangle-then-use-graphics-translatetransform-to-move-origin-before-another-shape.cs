using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\Temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new BMP image with specified dimensions
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the background
            graphics.Clear(Color.Wheat);

            // Draw the first rectangle (red)
            Pen redPen = new Pen(Color.Red, 3);
            graphics.DrawRectangle(redPen, new Rectangle(50, 50, 200, 150));

            // Translate the origin by (100, 100)
            graphics.TranslateTransform(100f, 100f);

            // Draw the second rectangle (blue) after translation
            Pen bluePen = new Pen(Color.Blue, 3);
            graphics.DrawRectangle(bluePen, new Rectangle(0, 0, 200, 150));

            // Save the image
            image.Save();
        }
    }
}