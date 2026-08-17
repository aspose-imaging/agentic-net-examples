// HOW-TO: Create BMP with Nested Colored Rectangles Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\temp\nested_rectangles.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500x500 image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Parameters for nested rectangles
                int rectCount = 10;
                int marginStep = 20;
                int startX = 0, startY = 0, width = image.Width, height = image.Height;

                // Alternate colors
                Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple };

                for (int i = 0; i < rectCount; i++)
                {
                    // Choose color cyclically
                    Pen pen = new Pen(colors[i % colors.Length], 2);
                    // Draw rectangle
                    graphics.DrawRectangle(pen, new Rectangle(startX, startY, width, height));

                    // Reduce size for next rectangle
                    startX += marginStep;
                    startY += marginStep;
                    width -= 2 * marginStep;
                    height -= 2 * marginStep;
                }

                // Save the image (file is already bound to outputPath)
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
 * 1. When you need to generate a BMP placeholder image with concentric colored frames for UI mock‑ups or documentation.
 * 2. When creating a simple test pattern to verify that BMP export and drawing APIs in Aspose.Imaging work correctly.
 * 3. When producing a series of nested shapes for a printable report that requires a 24‑bit BMP with alternating colors.
 * 4. When building a dynamic badge or logo that consists of layered rectangles and must be saved as a BMP file.
 * 5. When automating the creation of visual guides or tutorials that illustrate margin calculations using C# graphics.
 */
