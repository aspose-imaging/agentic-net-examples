using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\vertical_lines.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a BMP image with desired dimensions
        var bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24 // 24‑bpp true color
        };

        int imageWidth = 800;
        int imageHeight = 600;

        using (Image image = Image.Create(bmpOptions, imageWidth, imageHeight))
        {
            // Initialize graphics object for drawing
            var graphics = new Graphics(image);

            // Thin black pen
            var pen = new Pen(Color.Black, 1);

            // Draw ten equally spaced vertical lines
            int lineCount = 10;
            // Spacing calculated so lines are inside the image borders
            int spacing = imageWidth / (lineCount + 1);
            for (int i = 1; i <= lineCount; i++)
            {
                int x = i * spacing;
                graphics.DrawLine(pen, x, 0, x, imageHeight);
            }

            // Save the image to the specified path
            image.Save(outputPath);
        }
    }
}