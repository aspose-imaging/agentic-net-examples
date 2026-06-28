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
            // Output directory for generated BMP files
            string outputDir = @"C:\temp\BatchBmp";
            Directory.CreateDirectory(outputDir);

            int imageCount = 5;      // Number of images to generate
            int width = 200;         // Canvas width
            int height = 200;        // Canvas height
            Random rand = new Random();

            for (int i = 0; i < imageCount; i++)
            {
                string outputPath = Path.Combine(outputDir, $"image_{i + 1}.bmp");
                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options bound to the output file
                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };

                // Create a BMP canvas
                using (BmpImage canvas = (BmpImage)Image.Create(options, width, height))
                {
                    // Draw random lines on the canvas
                    Graphics graphics = new Graphics(canvas);
                    int lineCount = 10;
                    for (int l = 0; l < lineCount; l++)
                    {
                        int x1 = rand.Next(width);
                        int y1 = rand.Next(height);
                        int x2 = rand.Next(width);
                        int y2 = rand.Next(height);
                        Color lineColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                        Pen pen = new Pen(lineColor, 1);
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
 * 1. When a developer needs to generate a set of BMP test images with random line patterns to validate image rendering pipelines in a .NET application.
 * 2. When QA engineers require bulk BMP files with varied colors and line positions to stress‑test a graphics compression algorithm implemented with Aspose.Imaging for .NET.
 * 3. When a machine‑learning team wants to create synthetic training data of simple line drawings in BMP format for evaluating edge‑detection models.
 * 4. When a software vendor must produce sample BMP assets automatically for documentation or demo pages that showcase the drawing capabilities of the Aspose.Imaging Graphics class.
 * 5. When an automated build process needs to generate temporary BMP files with random line art to verify that file‑system permissions and file‑creation logic work correctly on different Windows environments.
 */