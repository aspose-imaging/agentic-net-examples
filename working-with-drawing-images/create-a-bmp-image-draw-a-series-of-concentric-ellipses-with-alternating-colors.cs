using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = @"C:\temp\concentric_ellipses.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw concentric ellipses with alternating colors
                int ellipseCount = 5;
                int marginStep = 20;
                for (int i = 0; i < ellipseCount; i++)
                {
                    int margin = i * marginStep;
                    int size = 500 - 2 * margin;
                    Rectangle rect = new Rectangle(margin, margin, size, size);
                    Color penColor = (i % 2 == 0) ? Color.Red : Color.Blue;
                    Pen pen = new Pen(penColor, 3);
                    graphics.DrawEllipse(pen, rect);
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
 * 1. When a developer needs to generate a BMP file with a simple geometric pattern for testing image rendering pipelines.
 * 2. When a developer wants to create a placeholder logo or watermark consisting of concentric ellipses with alternating colors for UI mockups.
 * 3. When a developer must produce a series of BMP assets for a game’s level‑selection screen that uses concentric ellipse graphics as visual cues.
 * 4. When a developer is building an automated report that embeds a BMP diagram of concentric ellipses to illustrate scaling or zoom concepts.
 * 5. When a developer needs to benchmark the performance of Aspose.Imaging’s Graphics.DrawEllipse method on 24‑bit BMP images.
 */