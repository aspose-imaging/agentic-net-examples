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
        // Hard‑coded paths
        string outputPath = @"C:\temp\concentric_rectangles.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set BMP creation options (24‑bit colour)
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                // The FileCreateSource tells Aspose where to write the new file
                Source = new FileCreateSource(outputPath, false)
            };

            const int imageWidth = 500;
            const int imageHeight = 500;
            const int rectangleCount = 10;          // Number of concentric rectangles
            const int step = 20;                    // Gap between successive rectangles

            // Create a new BMP image
            using (Image image = Image.Create(bmpOptions, imageWidth, imageHeight))
            {
                // Initialise graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Fill background with white
                graphics.Clear(Color.White);

                // Colours to alternate between
                Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple };

                // Draw concentric rectangles
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

                    // Choose pen colour cyclically
                    Pen pen = new Pen(colors[i % colors.Length], 3f);

                    // Draw the rectangle
                    graphics.DrawRectangle(pen, rect);
                }

                // Save changes (the file was already created by FileCreateSource)
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
 * 1. When a developer needs to generate a 24‑bit BMP thumbnail that visualizes nested layout zones for a UI mock‑up, this code can draw concentric rectangles with alternating pen colors.
 * 2. When creating test images to validate edge‑detection or shape‑recognition algorithms, the code provides a predictable BMP containing multiple rectangles of known dimensions.
 * 3. When producing printable pattern overlays for packaging design, developers can use this C# snippet to programmatically create a BMP with layered frames in alternating colors.
 * 4. When building a diagnostic tool that marks different resolution levels on a map or diagram, the code can render concentric rectangles on a BMP canvas to illustrate each level.
 * 5. When automating the generation of placeholder graphics for documentation or UI components, this code quickly creates a BMP file with concentric rectangles to demonstrate spacing and padding concepts.
 */