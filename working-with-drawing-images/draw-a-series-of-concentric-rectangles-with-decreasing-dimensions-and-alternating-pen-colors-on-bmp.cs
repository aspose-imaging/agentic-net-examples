using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\Temp\concentric_rectangles.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP options with 24 bits per pixel
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false) // The file will be created
        };

        // Define image dimensions
        int imageWidth = 500;
        int imageHeight = 500;

        // Create a new BMP image
        using (Image image = Image.Create(bmpOptions, imageWidth, imageHeight))
        {
            // Initialize graphics object
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Number of concentric rectangles
            int rectangleCount = 10;
            // Pen width
            float penWidth = 5f;

            // Colors to alternate between
            Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple };

            for (int i = 0; i < rectangleCount; i++)
            {
                // Calculate margin so each rectangle is smaller than the previous
                int margin = i * 20;
                int rectWidth = imageWidth - 2 * margin;
                int rectHeight = imageHeight - 2 * margin;

                // Ensure dimensions stay positive
                if (rectWidth <= 0 || rectHeight <= 0)
                    break;

                // Create rectangle
                Rectangle rect = new Rectangle(margin, margin, rectWidth, rectHeight);

                // Choose color cyclically
                Color penColor = colors[i % colors.Length];
                Pen pen = new Pen(penColor, penWidth);

                // Draw the rectangle
                graphics.DrawRectangle(pen, rect);
            }

            // Save the image (the file was already created by FileCreateSource, but Save finalizes)
            image.Save();
        }
    }
}