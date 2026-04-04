using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hard‑coded output path
        string outputPath = @"C:\temp\concentric_rectangles.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // BMP creation options
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Image dimensions
        int imageWidth = 500;
        int imageHeight = 500;

        // Create the image
        using (Image image = Image.Create(bmpOptions, imageWidth, imageHeight))
        {
            // Initialize graphics object
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Parameters for concentric rectangles
            int rectangleCount = 10;          // number of rectangles
            int step = 20;                    // reduction per side for each inner rectangle
            float penWidth = 3f;              // pen thickness

            for (int i = 0; i < rectangleCount; i++)
            {
                int offset = i * step;
                // Prevent negative width/height
                if (imageWidth - 2 * offset <= 0 || imageHeight - 2 * offset <= 0)
                    break;

                // Define rectangle bounds
                Rectangle rect = new Rectangle(
                    offset,
                    offset,
                    imageWidth - 2 * offset,
                    imageHeight - 2 * offset);

                // Alternate colors: Red, Blue, Red, Blue, ...
                Color penColor = (i % 2 == 0) ? Color.Red : Color.Blue;
                Pen pen = new Pen(penColor, penWidth);

                // Draw the rectangle
                graphics.DrawRectangle(pen, rect);
            }

            // Save changes (the file was created via FileCreateSource)
            image.Save();
        }
    }
}