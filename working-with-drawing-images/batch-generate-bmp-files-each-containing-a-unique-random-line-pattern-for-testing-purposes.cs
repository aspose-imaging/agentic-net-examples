// HOW-TO: Generate Multiple Random Line BMP Images for Testing in C# (Aspose.Imaging for .NET)
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
            // Output directory (relative)
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            int imageCount = 10;          // Number of BMP files to generate
            int width = 500;              // Canvas width
            int height = 500;             // Canvas height
            Random rnd = new Random();

            for (int i = 0; i < imageCount; i++)
            {
                string outputPath = Path.Combine(outputDir, $"image_{i}.bmp");
                // Ensure the directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with file source
                Source source = new FileCreateSource(outputPath, false);
                BmpOptions bmpOptions = new BmpOptions
                {
                    Source = source,
                    BitsPerPixel = 24
                };

                // Create a new BMP image (bound to the file source)
                using (Image canvas = Image.Create(bmpOptions, width, height))
                {
                    // Draw on the canvas
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    int lines = rnd.Next(5, 11); // Random number of lines per image
                    for (int l = 0; l < lines; l++)
                    {
                        // Random start and end points
                        int x1 = rnd.Next(width);
                        int y1 = rnd.Next(height);
                        int x2 = rnd.Next(width);
                        int y2 = rnd.Next(height);

                        // Random color
                        Color lineColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                        // Random thickness between 1 and 5
                        float thickness = (float)rnd.NextDouble() * 4f + 1f;

                        Pen pen = new Pen(lineColor, thickness);
                        graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
                    }

                    // Save the bound image
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
 * 1. When you need a set of sample BMP files with varied line drawings to benchmark image processing algorithms.
 * 2. When creating synthetic test data for computer vision models that detect line patterns in bitmap images.
 * 3. When populating a UI component with placeholder graphics to evaluate rendering performance in a .NET application.
 * 4. When automating stress tests for file I/O and memory usage by writing dozens of BMP files with random content.
 * 5. When generating visual assets for unit tests that require deterministic yet unpredictable line configurations.
 */
