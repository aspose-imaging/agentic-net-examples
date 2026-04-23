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
        string outputPath = @"C:\temp\ellipse.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas of 800x600 pixels
        using (Image image = Image.Create(pngOptions, 800, 600))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Draw a red ellipse with a 2-pixel pen
            // Rectangle(x, y, width, height) defines the bounding box of the ellipse
            graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(100, 100, 600, 400));

            // Save the image (writes to the file specified in pngOptions.Source)
            image.Save();
        }
    }
}