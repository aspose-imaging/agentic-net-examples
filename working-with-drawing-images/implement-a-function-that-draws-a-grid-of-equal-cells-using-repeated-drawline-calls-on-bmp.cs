using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = @"C:\temp\grid.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Grid parameters
        int cellSize = 50;      // size of each cell in pixels
        int columns = 10;       // number of columns
        int rows = 8;           // number of rows
        int width = columns * cellSize;
        int height = rows * cellSize;

        // Create BMP image bound to the output file
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath);

        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics and pen
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

            // Save the image (output file already bound)
            image.Save();
        }
    }
}