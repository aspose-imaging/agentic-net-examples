using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\temp\concentric_circles.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Canvas size
            int width = 500;
            int height = 500;

            // Create the image canvas bound to the output file
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Center of the canvas
                int centerX = width / 2;
                int centerY = height / 2;

                // Maximum radius (leaving a small margin)
                int maxRadius = Math.Min(width, height) / 2 - 10;
                int step = 20; // radius decrement step
                bool useRed = true; // toggle color

                // Draw concentric circles
                for (int radius = maxRadius; radius > 0; radius -= step)
                {
                    Color circleColor = useRed ? Color.Red : Color.Blue;
                    Pen pen = new Pen(circleColor, 2);

                    int x = centerX - radius;
                    int y = centerY - radius;
                    int diameter = radius * 2;

                    graphics.DrawEllipse(pen, new Rectangle(x, y, diameter, diameter));

                    useRed = !useRed; // alternate color
                }

                // Save the image (output path already bound)
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
 * 1. When a developer needs to generate a BMP file that visualizes radar range rings for a mapping application, they can use this code to draw concentric circles with alternating colors.
 * 2. When creating printable test patterns for calibrating scanners or printers, a developer can employ this C# Aspose.Imaging snippet to produce a 500 × 500 BMP image of alternating red and blue circles.
 * 3. When building a simple educational tool that demonstrates basic geometry concepts such as radius and diameter, a programmer can use this code to render concentric circles directly onto a bitmap.
 * 4. When an IoT device must send a lightweight BMP thumbnail showing signal‑strength zones, the code can create the image on‑the‑fly using Aspose.Imaging’s Graphics API.
 * 5. When a game developer wants to generate a circular health‑meter overlay as a BMP asset during a build pipeline, this example provides a quick way to draw layered circles with alternating colors.
 */