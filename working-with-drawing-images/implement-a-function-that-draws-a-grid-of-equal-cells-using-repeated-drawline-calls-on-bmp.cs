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
            string outputPath = "output_grid.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int cellSize = 50;
            int rows = 10;
            int cols = 10;
            int width = cellSize * cols;
            int height = cellSize * rows;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 1);

                for (int c = 0; c <= cols; c++)
                {
                    int x = c * cellSize;
                    graphics.DrawLine(pen, x, 0, x, height);
                }

                for (int r = 0; r <= rows; r++)
                {
                    int y = r * cellSize;
                    graphics.DrawLine(pen, 0, y, width, y);
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
 * 1. When a developer needs to generate a printable BMP spreadsheet‑style layout for a game board or seating chart, they can use this code to draw a grid of equal cells.
 * 2. When creating a background image for a UI control that requires a tiled pattern, the repeated DrawLine calls produce a BMP grid that can be tiled across the interface.
 * 3. When exporting a data matrix to a BMP file for legacy systems that only accept bitmap images, this code quickly renders the rows and columns as a visual grid.
 * 4. When building a simple image‑based maze or puzzle where walls are aligned on a regular grid, the grid‑drawing routine provides the base BMP canvas for further drawing.
 * 5. When testing image processing pipelines or benchmarking Aspose.Imaging’s Graphics API, developers can use this code to generate a known‑size BMP grid for validation.
 */