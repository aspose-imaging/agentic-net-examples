using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded output path
        string outputPath = @"C:\temp\nested_rectangles.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Image dimensions
            int width = 500;
            int height = 500;

            // Create the image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Parameters for nested rectangles
                int rectCount = 6;                     // number of rectangles
                int marginStep = 30;                   // reduction per level
                int startMargin = 0;                   // initial margin
                Color[] colors = new Color[]
                {
                    Color.Red,
                    Color.Blue,
                    Color.Green,
                    Color.Orange,
                    Color.Purple,
                    Color.Brown
                };

                // Draw each rectangle
                for (int i = 0; i < rectCount; i++)
                {
                    int margin = startMargin + i * marginStep;
                    int rectWidth = width - 2 * margin;
                    int rectHeight = height - 2 * margin;
                    int x = margin;
                    int y = margin;

                    // Choose pen color, alternating through the array
                    Pen pen = new Pen(colors[i % colors.Length], 3f);
                    graphics.DrawRectangle(pen, new Rectangle(x, y, rectWidth, rectHeight));
                }

                // Save changes (the output path is already defined in the source)
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
 * 1. When a developer needs to generate a BMP file that visualizes hierarchical data as a series of nested rectangles with alternating colors for a quick UI preview.
 * 2. When creating test images for automated image‑processing pipelines that require known geometric shapes and color patterns in a 24‑bit BMP using C# and Aspose.Imaging.
 * 3. When producing printable artwork such as a simple mandala or decorative border where each concentric rectangle is drawn with a different pen color and saved as a BMP for downstream design tools.
 * 4. When building a diagnostic tool that renders performance metrics as nested colored boxes in a BMP to help developers spot layout issues in a Windows desktop application.
 * 5. When generating placeholder graphics for documentation or mock‑ups that need a scalable BMP showing multiple layers of rectangles with distinct colors without relying on external image editors.
 */