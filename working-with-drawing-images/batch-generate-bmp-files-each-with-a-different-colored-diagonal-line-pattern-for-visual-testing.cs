// HOW-TO: Create Multiple BMP Images with Colored Diagonal Lines in C# (Aspose.Imaging for .NET)
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
            string outputDirectory = "output";
            int width = 200;
            int height = 200;
            Color[] colors = new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                Color.Magenta,
                Color.Cyan,
                Color.Black,
                Color.White
            };

            for (int i = 0; i < colors.Length; i++)
            {
                string outputPath = Path.Combine(outputDirectory, $"DiagonalLine_{i + 1}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                BmpOptions bmpOptions = new BmpOptions();

                using (RasterImage image = (RasterImage)Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    Pen pen = new Pen(colors[i], 5);
                    graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));
                    image.Save(outputPath, bmpOptions);
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
 * 1. When you need a set of BMP test files each showing a different colored diagonal line to verify rendering pipelines or display hardware.
 * 2. When generating sample assets for UI components that require diagonal line graphics in various colors for documentation or demos.
 * 3. When creating placeholder images for automated visual regression tests that compare colored line patterns across builds.
 * 4. When producing a batch of simple bitmap images for teaching graphics programming concepts such as drawing primitives and color handling in C#.
 * 5. When preparing colored diagonal line sprites for game development tools that only accept BMP format and need quick batch generation.
 */
