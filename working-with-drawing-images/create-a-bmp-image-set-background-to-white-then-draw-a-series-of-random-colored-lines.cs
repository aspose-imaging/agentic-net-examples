// HOW-TO: Create BMP Image with Random Colored Lines in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            int width = 800;
            int height = 600;

            using (var bmpOptions = new BmpOptions())
            {
                bmpOptions.Source = new FileCreateSource(outputPath, false);
                using (var image = Image.Create(bmpOptions, width, height))
                {
                    var graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    var rand = new Random();
                    int lineCount = 20;
                    for (int i = 0; i < lineCount; i++)
                    {
                        int x1 = rand.Next(width);
                        int y1 = rand.Next(height);
                        int x2 = rand.Next(width);
                        int y2 = rand.Next(height);
                        var color = Color.FromArgb(255, rand.Next(256), rand.Next(256), rand.Next(256));
                        var pen = new Pen(color);
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
 * 1. When you need to generate a placeholder BMP file with a white background and random colored line patterns for testing image rendering pipelines.
 * 2. When you want to create a simple visual noise texture in BMP format for use as a background in games or UI prototypes.
 * 3. When you need to programmatically produce a BMP diagram that visualizes random line data for debugging drawing algorithms.
 * 4. When you are building a batch process that creates sample BMP files with varied line colors to evaluate compression performance.
 * 5. When you require an automated way to generate BMP graphics with random lines for teaching basic graphics programming concepts in C#.
 */
