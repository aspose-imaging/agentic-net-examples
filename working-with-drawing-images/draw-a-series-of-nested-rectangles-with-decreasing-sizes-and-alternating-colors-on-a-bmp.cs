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

        // Set up BMP options
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a 500x500 BMP image
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics object
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Define rectangle parameters
            int rectCount = 8;                     // Number of nested rectangles
            int startSize = 400;                   // Size of the outermost rectangle
            int startX = (image.Width - startSize) / 2;
            int startY = (image.Height - startSize) / 2;
            int decrement = 40;                    // Size reduction for each inner rectangle

            // Colors to alternate between
            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow };

            for (int i = 0; i < rectCount; i++)
            {
                int size = startSize - i * decrement;
                int x = startX + i * (decrement / 2);
                int y = startY + i * (decrement / 2);

                // Choose color based on index
                Color penColor = colors[i % colors.Length];
                Pen pen = new Pen(penColor, 3f);

                // Draw the rectangle
                graphics.DrawRectangle(pen, new Rectangle(x, y, size, size));
            }

            // Save changes (the source already points to outputPath)
            image.Save();
        }
    }
}