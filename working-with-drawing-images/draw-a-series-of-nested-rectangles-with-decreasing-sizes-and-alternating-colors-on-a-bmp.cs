// HOW-TO: Create BMP Image with Nested Colored Rectangles in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "nested_rectangles.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 32;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                int rectCount = 10;
                int marginStep = 20;

                for (int i = 0; i < rectCount; i++)
                {
                    int margin = i * marginStep;
                    int rectWidth = width - 2 * margin;
                    int rectHeight = height - 2 * margin;
                    if (rectWidth <= 0 || rectHeight <= 0) break;

                    Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(margin, margin, rectWidth, rectHeight);
                    Aspose.Imaging.Color fillColor = (i % 2 == 0) ? Aspose.Imaging.Color.Red : Aspose.Imaging.Color.Blue;

                    using (SolidBrush brush = new SolidBrush(fillColor))
                    {
                        graphics.FillRectangle(brush, rect);
                    }
                }

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
 * 1. When you need to generate a BMP file that visualizes layered data by drawing concentric rectangles with alternating colors for UI mock‑ups or reports.
 * 2. When creating programmatic test patterns to verify image rendering pipelines or color calibration on display devices using Aspose.Imaging.
 * 3. When producing simple graphic assets such as icons, badges, or placeholders that require a series of decreasing rectangles without using external design tools.
 * 4. When automating the creation of background textures or frames for games and applications where each layer has a distinct color for visual depth.
 * 5. When demonstrating or teaching basic drawing operations in C# by programmatically clearing a canvas and filling shapes with solid brushes.
 */
