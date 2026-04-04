using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\Temp\concentric_circles.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // BMP options with 24 bits per pixel
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        int width = 500;
        int height = 500;

        // Create the BMP image bound to the output file
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Center of the image
            int centerX = width / 2;
            int centerY = height / 2;

            // Define radii and alternating colors
            int maxRadius = Math.Min(width, height) / 2 - 10;
            int step = 20;
            Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple };

            int colorIndex = 0;
            for (int radius = maxRadius; radius > 0; radius -= step)
            {
                // Calculate bounding rectangle for the circle
                int x = centerX - radius;
                int y = centerY - radius;
                int diameter = radius * 2;

                // Create pen with current color
                Pen pen = new Pen(colors[colorIndex % colors.Length], 3);

                // Draw the circle (ellipse with equal width and height)
                graphics.DrawEllipse(pen, new Rectangle(x, y, diameter, diameter));

                colorIndex++;
            }

            // Save the image (output file already bound)
            image.Save();
        }
    }
}