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
        // Hard‑coded input/output paths (no argument validation)
        string outputPath = @"C:\temp\nested_rectangles.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up BMP options (24‑bpp) and the file to be created
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500×500 image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Colors to alternate between
                Color[] colors = new Color[]
                {
                    Color.Red,
                    Color.Blue,
                    Color.Green,
                    Color.Orange
                };

                int rectCount = 10;          // Number of nested rectangles
                int step = 20;               // Size reduction per level
                int imageSize = 500;         // Width/height of the image

                // Draw nested rectangles
                for (int i = 0; i < rectCount; i++)
                {
                    int offset = i * step;
                    int size = imageSize - 2 * offset;

                    // Define rectangle bounds
                    Rectangle rect = new Rectangle(offset, offset, size, size);

                    // Create pen with alternating color
                    Pen pen = new Pen(colors[i % colors.Length], 3f);

                    // Draw the rectangle outline
                    graphics.DrawRectangle(pen, rect);
                }

                // Save changes to the BMP file
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}