// HOW-TO: Create Multiple BMP Images with Centered Squares from Size List in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            var specs = new List<(int width, int height)>
            {
                (200, 200),
                (300, 150),
                (400, 400)
            };

            int index = 1;
            foreach (var spec in specs)
            {
                int width = spec.width;
                int height = spec.height;

                string fileName = $"image_{index}.bmp";
                string outputPath = Path.Combine(outputDir, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Source source = new FileCreateSource(outputPath, false);
                BmpOptions bmpOptions = new BmpOptions { Source = source };

                using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    int squareSize = Math.Min(width, height) / 2;
                    int offsetX = (width - squareSize) / 2;
                    int offsetY = (height - squareSize) / 2;

                    using (SolidBrush brush = new SolidBrush(Color.Black))
                    {
                        graphics.FillRectangle(brush, new Rectangle(offsetX, offsetY, squareSize, squareSize));
                    }

                    canvas.Save();
                }

                index++;
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
 * 1. When you need to generate placeholder BMP files of various dimensions for testing UI layouts.
 * 2. When you want to programmatically create a set of icons with a centered square logo for a game asset pipeline.
 * 3. When you must produce batch BMP thumbnails with a consistent centered shape for legacy printing systems.
 * 4. When you are preparing sample images for documentation that require different canvas sizes but a uniform centered element.
 * 5. When you automate the creation of BMP masks of varying sizes for image processing experiments using Aspose.Imaging in C#.
 */
