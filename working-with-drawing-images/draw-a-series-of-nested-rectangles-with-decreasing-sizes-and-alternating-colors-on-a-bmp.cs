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
        string outputPath = @"C:\temp\nested_rectangles.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP options
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Define image size
        int width = 500;
        int height = 500;

        // Create a new BMP image
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics object
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Parameters for nested rectangles
            int rectangleCount = 10;
            int marginStep = 20; // Decrease size by this amount each step
            int penWidth = 3;

            for (int i = 0; i < rectangleCount; i++)
            {
                // Calculate rectangle position and size
                int margin = i * marginStep;
                int rectWidth = width - 2 * margin;
                int rectHeight = height - 2 * margin;
                Rectangle rect = new Rectangle(margin, margin, rectWidth, rectHeight);

                // Alternate colors between Red and Blue
                Color rectColor = (i % 2 == 0) ? Color.Red : Color.Blue;
                Pen pen = new Pen(rectColor, penWidth);

                // Draw the rectangle
                graphics.DrawRectangle(pen, rect);
            }

            // Save the image (the file is already created via FileCreateSource)
            image.Save();
        }
    }
}