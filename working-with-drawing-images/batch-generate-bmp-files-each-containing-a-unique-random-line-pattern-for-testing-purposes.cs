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
            int imageCount = 5;          // Number of BMP files to generate
            int width = 200;             // Canvas width
            int height = 200;            // Canvas height
            Random rand = new Random();

            for (int i = 1; i <= imageCount; i++)
            {
                // Output file path (hard‑coded)
                string outputPath = $"Output/image_{i}.bmp";

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create a bound BMP image using FileCreateSource
                Source source = new FileCreateSource(outputPath, false);
                BmpOptions bmpOptions = new BmpOptions() { Source = source, BitsPerPixel = 24 };

                using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
                {
                    // Draw random lines onto the canvas
                    Graphics graphics = new Graphics(canvas);
                    int lines = 10;
                    for (int l = 0; l < lines; l++)
                    {
                        // Random color and pen width
                        Aspose.Imaging.Color lineColor = Aspose.Imaging.Color.FromArgb(
                            255,
                            rand.Next(256),
                            rand.Next(256),
                            rand.Next(256));
                        Pen pen = new Pen(lineColor, rand.Next(1, 5));

                        // Random start and end points
                        Point start = new Point(rand.Next(width), rand.Next(height));
                        Point end = new Point(rand.Next(width), rand.Next(height));

                        graphics.DrawLine(pen, start, end);
                    }

                    // Save the bound image (no path needed)
                    canvas.Save();
                }
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
 * 1. When a QA engineer needs a set of sample BMP images with unpredictable line patterns to validate image rendering performance in a C# application.
 * 2. When a developer is creating stress‑test data for a graphics pipeline that reads 24‑bit BMP files and must handle varying colors and pen widths.
 * 3. When a machine‑learning researcher wants to generate synthetic training data of random line drawings stored as BMP files for a line‑detection algorithm.
 * 4. When a software vendor needs to demonstrate the Aspose.Imaging API’s ability to create bound images using FileCreateSource and draw graphics with the Graphics class.
 * 5. When an automated build script must produce placeholder BMP assets with random content to ensure downstream tools correctly process image files in a .NET CI/CD workflow.
 */