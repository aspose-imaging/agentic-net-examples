// HOW-TO: Create BMP with White Background and Random Colored Lines in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image (800x600) using the BMP options
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 800, 600))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Fill background with white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Random generator for colors, positions and pen widths
                Random rand = new Random();

                // Draw 100 random colored lines
                for (int i = 0; i < 100; i++)
                {
                    // Random color
                    Aspose.Imaging.Color lineColor = Aspose.Imaging.Color.FromArgb(
                        255,
                        (byte)rand.Next(256),
                        (byte)rand.Next(256),
                        (byte)rand.Next(256));

                    // Random pen width between 1 and 5
                    int penWidth = rand.Next(1, 6);
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(lineColor, penWidth);

                    // Random start and end points within image bounds
                    int x1 = rand.Next(0, image.Width);
                    int y1 = rand.Next(0, image.Height);
                    int x2 = rand.Next(0, image.Width);
                    int y2 = rand.Next(0, image.Height);

                    // Draw the line
                    graphics.DrawLine(pen, x1, y1, x2, y2);
                }

                // Save the image (output is already bound via FileCreateSource)
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
 * 1. When you need to generate a placeholder BMP image with random colored lines using Aspose.Imaging for UI testing.
 * 2. When you want to programmatically create a white‑background bitmap that serves as a background texture for a game level editor.
 * 3. When you need to produce a simple random‑line pattern as a watermark or visual texture in a graphics pipeline.
 * 4. When you are building a diagnostic tool that visualizes random data streams as colored lines on a BMP file.
 * 5. When you require an automated way to generate sample BMP files with varied colors for performance benchmarking of image‑processing algorithms.
 */
