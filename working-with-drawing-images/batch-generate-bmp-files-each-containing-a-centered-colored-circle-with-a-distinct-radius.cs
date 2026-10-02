// HOW-TO: Create Multiple BMP Images with Centered Red Circles of Varying Radii in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = "OutputImages";
            Directory.CreateDirectory(outputDir);

            int[] radii = new int[] { 20, 40, 60, 80, 100 };
            foreach (int radius in radii)
            {
                int width = radius * 2 + 20;
                int height = width;
                string outputPath = Path.Combine(outputDir, $"circle_{radius}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };

                using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red))
                    {
                        int left = (width - radius * 2) / 2;
                        int top = (height - radius * 2) / 2;
                        Rectangle rect = new Rectangle(left, top, radius * 2, radius * 2);
                        graphics.FillEllipse(brush, rect);
                    }

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
 * 1. When you need to generate a batch of BMP icons that display centered red circles of different sizes for UI testing or prototyping.
 * 2. When you want to programmatically produce placeholder graphics for documentation that require a simple centered shape in a raster format.
 * 3. When you are creating game assets where each BMP file represents a target area with a specific radius for level design.
 * 4. When you need calibration images for computer‑vision algorithms that require circles of known dimensions saved as BMP files.
 * 5. When you must export simple vector‑like shapes to BMP format for legacy systems that only accept raster images.
 */
