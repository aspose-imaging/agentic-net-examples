// HOW-TO: Generate Multiple Random Line Pattern BMP Images in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
            string outputDir = "GeneratedLines";
            Directory.CreateDirectory(outputDir);

            int imageCount = 10;
            int width = 800;
            int height = 600;
            Random rand = new Random();

            for (int i = 0; i < imageCount; i++)
            {
                string outputPath = Path.Combine(outputDir, $"pattern_{i + 1}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    int lineCount = 20;
                    for (int j = 0; j < lineCount; j++)
                    {
                        int x1 = rand.Next(width);
                        int y1 = rand.Next(height);
                        int x2 = rand.Next(width);
                        int y2 = rand.Next(height);
                        int r = rand.Next(256);
                        int g = rand.Next(256);
                        int b = rand.Next(256);
                        Color lineColor = Color.FromArgb(255, r, g, b);

                        Pen pen = new Pen(lineColor, 2);
                        graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
                    }

                    image.Save();
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
 * 1. When you need a set of BMP files with random line graphics to stress‑test image‑processing algorithms or benchmark drawing performance.
 * 2. When creating synthetic test data for computer‑vision models that require varied line patterns in a known resolution and format.
 * 3. When generating placeholder graphics for UI mockups or documentation where each image must be visually distinct without manual design.
 * 4. When automating the production of sample BMP assets for a graphics library’s unit tests that verify handling of multiple colors and line thicknesses.
 * 5. When preparing a batch of random line images to simulate noisy scan data for OCR or pattern‑recognition evaluation.
 */
