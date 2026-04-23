using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = "output\\curved.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a new BMP image with desired dimensions
        var bmpOptions = new BmpOptions();
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics object for drawing
            var graphics = new Graphics(image);

            // Enable anti-aliasing for smoother curves
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Define points for the curved line
            Point[] curvePoints = new Point[]
            {
                new Point(50, 250),
                new Point(150, 50),
                new Point(250, 250),
                new Point(350, 50),
                new Point(450, 250)
            };

            // Create a pen with desired color and width
            var pen = new Pen(Color.Blue, 3);

            // Draw the curved line
            graphics.DrawCurve(pen, curvePoints);

            // Save the image to the specified path
            image.Save(outputPath);
        }
    }
}