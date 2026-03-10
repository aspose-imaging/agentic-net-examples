using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";
        if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
            outputPath = args[0];

        // Create a source for the PNG image
        Source source = new FileCreateSource(outputPath, false);

        // Configure PNG options with a memory limit (e.g., 30 MB)
        PngOptions pngOptions = new PngOptions
        {
            Source = source,
            BufferSizeHint = 30 // Memory limit in megabytes
        };

        const int imageSize = 2000; // Width and height of the image

        // Create the image with the specified options
        using (Image image = Image.Create(pngOptions, imageSize, imageSize))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a light background color
            graphics.Clear(Color.LightGray);

            // Begin batch update to reduce memory overhead for many operations
            graphics.BeginUpdate();

            // Example: draw a dense grid of lines
            int step = 20;
            Pen pen = new Pen(Color.DarkBlue, 1);
            for (int x = 0; x <= imageSize; x += step)
            {
                graphics.DrawLine(pen, x, 0, x, imageSize);
            }
            for (int y = 0; y <= imageSize; y += step)
            {
                graphics.DrawLine(pen, 0, y, imageSize, y);
            }

            // Example: draw concentric circles
            Pen circlePen = new Pen(Color.Red, 2);
            int maxRadius = imageSize / 2;
            for (int r = 0; r < maxRadius; r += 50)
            {
                graphics.DrawEllipse(circlePen, new Rectangle(imageSize / 2 - r, imageSize / 2 - r, r * 2, r * 2));
            }

            // End batch update to apply all drawing operations
            graphics.EndUpdate();

            // Save the image (the source is already bound, so just call Save())
            image.Save();
        }
    }
}