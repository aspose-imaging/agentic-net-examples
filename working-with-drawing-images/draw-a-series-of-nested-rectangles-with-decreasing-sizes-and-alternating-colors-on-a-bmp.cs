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
        // Hard‑coded paths
        string outputPath = @"C:\temp\nested_rectangles.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Create BMP options
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
                // Initialize graphics
                Graphics graphics = new Graphics(image);

                // Fill background with white
                graphics.Clear(Color.White);

                // Parameters for nested rectangles
                int rectangleCount = 10;
                int offsetStep = 20;
                float penWidth = 3f;

                // Draw rectangles decreasing in size, alternating colors
                for (int i = 0; i < rectangleCount; i++)
                {
                    int offset = i * offsetStep;
                    int rectWidth = imageWidth - 2 * offset;
                    int rectHeight = imageHeight - 2 * offset;

                    // Stop if rectangle would have non‑positive size
                    if (rectWidth <= 0 || rectHeight <= 0)
                        break;

                    // Define rectangle
                    Rectangle rect = new Rectangle(offset, offset, rectWidth, rectHeight);

                    // Alternate between Red and Blue
                    Color rectColor = (i % 2 == 0) ? Color.Red : Color.Blue;

                    // Create pen and draw rectangle
                    Pen pen = new Pen(rectColor, penWidth);
                    graphics.DrawRectangle(pen, rect);
                }

                // Save the image (already bound to outputPath via FileCreateSource)
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
 * 1. When a developer needs to generate a BMP thumbnail that visualizes hierarchical data as concentric colored rectangles for a reporting dashboard.
 * 2. When a C# application must create a printable test pattern with alternating red and blue borders to verify printer alignment and color accuracy.
 * 3. When a software tool requires a simple placeholder image showing nested shapes for UI mock‑ups or wireframes using Aspose.Imaging.
 * 4. When an automated script has to produce a series of BMP frames with decreasing rectangles for an animated loading indicator or progress bar.
 * 5. When a developer wants to programmatically generate a decorative background for a game level map by drawing layered rectangles with alternating colors.
 */