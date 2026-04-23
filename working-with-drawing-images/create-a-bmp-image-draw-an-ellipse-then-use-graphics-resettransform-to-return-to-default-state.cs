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
        string outputPath = @"c:\temp\ellipse.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new BMP image of size 500x500
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the background
            graphics.Clear(Aspose.Imaging.Color.Wheat);

            // Draw an ellipse with a black pen
            Pen pen = new Pen(Aspose.Imaging.Color.Black, 2);
            graphics.DrawEllipse(pen, new Rectangle(50, 50, 300, 300));

            // Reset any transformations to the default state
            graphics.ResetTransform();

            // Save the image (the file was specified in the source)
            image.Save();
        }
    }
}