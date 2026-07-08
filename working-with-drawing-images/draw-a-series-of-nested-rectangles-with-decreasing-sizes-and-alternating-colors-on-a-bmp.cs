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
        try
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

            // Create a new image of size 500x500
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Draw nested rectangles
                int rectCount = 5;
                int offsetStep = 20;
                int initialSize = 500;
                for (int i = 0; i < rectCount; i++)
                {
                    int offset = i * offsetStep;
                    int size = initialSize - 2 * offset;
                    // Alternate colors between Red and Blue
                    Color penColor = (i % 2 == 0) ? Color.Red : Color.Blue;
                    Pen pen = new Pen(penColor, 3f);
                    // Draw rectangle
                    graphics.DrawRectangle(pen, offset, offset, size, size);
                }

                // Save the image (the file is already created via FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a BMP file that visualizes hierarchical data as concentric colored rectangles for a quick UI mock‑up.
 * 2. When an automated reporting tool must create a 500×500 pixel image with alternating red and blue borders to highlight different sections of a diagram.
 * 3. When a game asset pipeline requires programmatically drawing nested shapes into a bitmap to use as a placeholder texture during development.
 * 4. When a testing framework needs to produce a deterministic image file for validating image‑processing algorithms that handle BMP format and color pens.
 * 5. When a documentation generator wants to embed a simple illustration of scaling and offset calculations by drawing decreasing rectangles with Aspose.Imaging in C#.
 */