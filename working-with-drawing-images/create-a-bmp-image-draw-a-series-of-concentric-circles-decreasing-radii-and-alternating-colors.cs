using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\concentric_circles.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 500x500 BMP image
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Center of the circles
            int centerX = 250;
            int centerY = 250;

            // Draw concentric circles with decreasing radii and alternating colors
            for (int radius = 200; radius > 0; radius -= 20)
            {
                // Alternate between Red and Blue
                Color fillColor = (radius / 20) % 2 == 0 ? Color.Red : Color.Blue;

                using (SolidBrush brush = new SolidBrush(fillColor))
                {
                    // Define bounding rectangle for the ellipse (circle)
                    Rectangle rect = new Rectangle(
                        centerX - radius,
                        centerY - radius,
                        radius * 2,
                        radius * 2);

                    // Fill the circle
                    graphics.FillEllipse(brush, rect);
                }
            }

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}