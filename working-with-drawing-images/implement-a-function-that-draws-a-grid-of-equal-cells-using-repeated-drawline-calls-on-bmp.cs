using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output file path (hardcoded)
        string outputPath = @"C:\temp\grid.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the BMP image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure BMP options with the stream source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new StreamSource(stream);

            // Grid parameters
            int cellSize = 50;      // Size of each cell (pixels)
            int rows = 10;          // Number of rows
            int cols = 10;          // Number of columns
            int width = cols * cellSize;
            int height = rows * cellSize;

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Pen for drawing grid lines
                Pen pen = new Pen(Color.Black, 1);

                // Draw horizontal lines
                for (int i = 0; i <= rows; i++)
                {
                    int y = i * cellSize;
                    graphics.DrawLine(pen, 0, y, width, y);
                }

                // Draw vertical lines
                for (int j = 0; j <= cols; j++)
                {
                    int x = j * cellSize;
                    graphics.DrawLine(pen, x, 0, x, height);
                }

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}