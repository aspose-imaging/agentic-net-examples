// HOW-TO: Create a BMP Checkerboard Pattern with Alternating Rectangles in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/checkerboard.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a file stream source
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(stream);

                int cellSize = 50;
                int rows = 8;
                int cols = 8;
                int width = cellSize * cols;
                int height = cellSize * rows;

                // Create the image canvas
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
                {
                    // Initialize graphics for drawing
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                    // Prepare brushes
                    using (SolidBrush whiteBrush = new SolidBrush(Aspose.Imaging.Color.White))
                    using (SolidBrush blackBrush = new SolidBrush(Aspose.Imaging.Color.Black))
                    {
                        for (int y = 0; y < rows; y++)
                        {
                            for (int x = 0; x < cols; x++)
                            {
                                Aspose.Imaging.Brushes.SolidBrush brush = ((x + y) % 2 == 0) ? whiteBrush : blackBrush;
                                graphics.FillRectangle(brush,
                                    new Aspose.Imaging.Rectangle(x * cellSize, y * cellSize, cellSize, cellSize));
                            }
                        }
                    }

                    // Save the image
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
 * 1. When you need to generate a chessboard‑style BMP image for a game UI or visual test using Aspose.Imaging in C#.
 * 2. When you want to produce a tiled black‑and‑white background for a Windows Forms or WPF application by drawing filled rectangles programmatically.
 * 3. When you require a simple high‑contrast pattern to calibrate or validate image‑processing and computer‑vision algorithms.
 * 4. When you are creating sample images for documentation or tutorials that demonstrate drawing primitives and brush usage with Aspose.Imaging.
 * 5. When you need an automated way to generate printable checkerboard patterns for scanner or printer calibration tasks.
 */
