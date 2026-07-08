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
            // Define output path
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create BMP options with bound file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Define canvas size
            int width = 500;
            int height = 500;

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear canvas to dark gray
                graphics.Clear(Color.DarkGray);

                // Draw bright yellow diagonal line
                Pen pen = new Pen(Color.Yellow, 1);
                graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

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
 * 1. When a developer needs to generate a BMP thumbnail with a dark‑gray background and a bright yellow diagonal marker for a file‑preview feature in a Windows desktop application.
 * 2. When an automated reporting tool must create a simple bitmap chart that highlights a trend line using a yellow diagonal on a gray canvas for quick visual inspection.
 * 3. When a game engine requires a placeholder texture in BMP format with a distinctive diagonal line to test rendering pipelines during development.
 * 4. When a batch image‑processing script has to produce diagnostic BMP images that show alignment by drawing a yellow diagonal across a dark gray background.
 * 5. When a documentation generator wants to embed a small BMP illustration showing a diagonal line example for teaching basic Aspose.Imaging drawing operations in C#.
 */