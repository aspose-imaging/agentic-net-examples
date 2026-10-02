// HOW-TO: Create a 10x10 Grid BMP Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/grid.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int cellSize = 50;
            int rows = 10;
            int cols = 10;
            int width = cols * cellSize;
            int height = rows * cellSize;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (RasterImage image = (RasterImage)Image.Create(options, width, height))
            {
                // Fill background with white
                int[] whitePixels = Enumerable.Repeat(Aspose.Imaging.Color.White.ToArgb(), width * height).ToArray();
                var rect = new Aspose.Imaging.Rectangle(0, 0, width, height);
                image.SaveArgb32Pixels(rect, whitePixels);

                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Aspose.Imaging.Color.Black, 1);

                // Draw vertical lines
                for (int c = 0; c <= cols; c++)
                {
                    int x = c * cellSize;
                    graphics.DrawLine(pen, x, 0, x, height);
                }

                // Draw horizontal lines
                for (int r = 0; r <= rows; r++)
                {
                    int y = r * cellSize;
                    graphics.DrawLine(pen, 0, y, width, y);
                }

                // Save the image (output already bound)
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
 * 1. When you need to generate a printable graph‑paper background as a BMP file for a Windows desktop application.
 * 2. When you want to create a game board such as chess or Sudoku dynamically at runtime without external image assets.
 * 3. When you must produce a tiled layout for a UI mock‑up or PDF overlay where each cell size is configurable.
 * 4. When you require a simple way to export a coordinate grid for scientific data visualization or calibration tools.
 * 5. When you need to programmatically draw a spreadsheet‑style grid for automated report generation in a .NET service.
 */
