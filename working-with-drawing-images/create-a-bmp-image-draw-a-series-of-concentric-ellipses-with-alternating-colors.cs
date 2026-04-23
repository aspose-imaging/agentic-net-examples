using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hardcoded)
        string outputPath = @"c:\temp\concentric_ellipses.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Parameters for concentric ellipses
            int centerX = 250;
            int centerY = 250;
            int maxRadius = 200;
            int step = 20;
            bool useBlue = true;

            // Draw ellipses with alternating colors
            for (int radius = maxRadius; radius > 0; radius -= step)
            {
                Color ellipseColor = useBlue ? Color.Blue : Color.Red;
                Pen pen = new Pen(ellipseColor, 2);

                int left = centerX - radius;
                int top = centerY - radius;
                int diameter = radius * 2;

                graphics.DrawEllipse(pen, left, top, diameter, diameter);
                useBlue = !useBlue;
            }

            // Save the image (output path already bound)
            image.Save();
        }
    }
}