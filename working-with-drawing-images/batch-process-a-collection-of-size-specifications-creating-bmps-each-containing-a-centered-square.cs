using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var sizes = new List<(int width, int height)>
            {
                (200, 200),
                (300, 150),
                (400, 400)
            };

            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            foreach (var size in sizes)
            {
                int width = size.width;
                int height = size.height;
                string outputPath = Path.Combine(outputDir, $"image_{width}x{height}.bmp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Source source = new FileCreateSource(outputPath, false);
                BmpOptions bmpOptions = new BmpOptions() { Source = source, BitsPerPixel = 24 };

                using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    int squareSide = Math.Min(width, height) / 2;
                    int offsetX = (width - squareSide) / 2;
                    int offsetY = (height - squareSide) / 2;

                    using (SolidBrush brush = new SolidBrush(Color.Blue))
                    {
                        graphics.FillRectangle(brush, new Rectangle(offsetX, offsetY, squareSide, squareSide));
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
 * 1. When a developer needs to generate a set of BMP thumbnails of varying dimensions with a centered square logo for a product catalog, they can use this batch processing code.
 * 2. When an application must create placeholder images of different sizes for UI mockups, automatically drawing a centered square to indicate content area, this C# Aspose.Imaging routine is ideal.
 * 3. When a reporting tool requires pre‑rendered BMP assets for printable charts, each sized to match page layouts and containing a centered square marker, the code can produce them in one pass.
 * 4. When a game developer wants to prepare sprite sheets of multiple resolutions, each BMP containing a centered square collision box for testing, the example shows how to automate the creation.
 * 5. When an e‑learning platform needs to generate lesson slide backgrounds of various aspect ratios with a centered square cue for interactive elements, this batch image generation approach fulfills the need.
 */