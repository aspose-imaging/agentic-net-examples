using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\checkerboard.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions and checkerboard settings
            int cellSize = 50;          // Size of each square
            int rows = 8;               // Number of rows
            int cols = 8;               // Number of columns
            int width = cols * cellSize;
            int height = rows * cellSize;

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Prepare brushes for black and white squares
                using (SolidBrush blackBrush = new SolidBrush(Color.Black))
                using (SolidBrush whiteBrush = new SolidBrush(Color.White))
                {
                    Graphics graphics = new Graphics(image);

                    // Draw the checkerboard pattern
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            SolidBrush brush = ((row + col) % 2 == 0) ? blackBrush : whiteBrush;
                            int x = col * cellSize;
                            int y = row * cellSize;
                            graphics.FillRectangle(brush, new Rectangle(x, y, cellSize, cellSize));
                        }
                    }
                }

                // Save the image to the bound file
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
 * 1. When a developer needs to generate a 24‑bit BMP checkerboard background for a game board UI using Aspose.Imaging in C#.
 * 2. When a developer wants to create a test BMP image with alternating black and white squares to verify image processing algorithms such as edge detection.
 * 3. When a developer must produce a printable black‑and‑white pattern for scanner or printer calibration by drawing filled rectangles into a BMP file.
 * 4. When a developer requires a dynamically generated tiled texture stored as a BMP file for a Windows Forms or WPF application.
 * 5. When a developer needs a simple placeholder image in BMP format for documentation, mockups, or UI design, using rectangle fills to create the pattern.
 */