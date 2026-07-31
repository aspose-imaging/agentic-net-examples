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
            // Output BMP file path (hardcoded)
            string outputPath = @"C:\Temp\grid.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Grid parameters
            int rows = 10;
            int columns = 10;
            int cellSize = 50; // pixels

            int width = columns * cellSize;
            int height = rows * cellSize;

            // Create BMP image bound to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Black, 1);

                // Draw vertical grid lines
                for (int col = 0; col <= columns; col++)
                {
                    int x = col * cellSize;
                    graphics.DrawLine(pen, x, 0, x, height);
                }

                // Draw horizontal grid lines
                for (int row = 0; row <= rows; row++)
                {
                    int y = row * cellSize;
                    graphics.DrawLine(pen, 0, y, width, y);
                }

                // Save the image (output path already bound)
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
 * 1. When generating a printable game board such as a chess or checkers board in BMP format for a Windows desktop application, a developer can use this code to draw the grid of equal cells.
 * 2. When creating a background template for a data‑entry form where each cell represents a field and the image must be saved as a BMP file, the repeated DrawLine calls provide the required grid.
 * 3. When producing a simple pixel‑art canvas that shows a tiled layout for designers to plan sprite placement, the code can generate the grid overlay in a BMP image.
 * 4. When exporting a floor‑plan sketch with uniformly spaced rooms to a BMP file for integration with legacy CAD systems, the grid drawing routine helps align the elements.
 * 5. When building a diagnostic tool that visualizes sensor data as a matrix of squares and needs to output the result as a BMP image, the grid created by this code separates each data cell.
 */