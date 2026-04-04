using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // List of image sizes (width, height)
        var sizes = new List<(int width, int height)>
        {
            (200, 200),
            (300, 150),
            (400, 400)
        };

        // Base output directory
        string baseOutputDir = @"C:\Temp\BatchOutputs";

        foreach (var (width, height) in sizes)
        {
            // Construct output file path
            string outputPath = Path.Combine(baseOutputDir, $"output_{width}x{height}.bmp");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with bound file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Determine ellipse size (half of canvas dimensions)
                int ellipseWidth = width / 2;
                int ellipseHeight = height / 2;
                int ellipseX = (width - ellipseWidth) / 2;
                int ellipseY = (height - ellipseHeight) / 2;

                // Draw centered red ellipse
                Pen redPen = new Pen(Color.Red, 2);
                Rectangle ellipseBounds = new Rectangle(ellipseX, ellipseY, ellipseWidth, ellipseHeight);
                graphics.DrawEllipse(redPen, ellipseBounds);

                // Save the bound image
                image.Save();
            }
        }
    }
}