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
        // Hardcoded input/output paths
        string outputPath = @"C:\temp\checkerboard.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Define image dimensions
            int width = 400;
            int height = 400;

            // Create the BMP canvas (bound to the output file)
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Checkerboard configuration
                int squaresPerRow = 8;
                int squareSize = width / squaresPerRow;

                // Draw alternating filled rectangles
                for (int row = 0; row < squaresPerRow; row++)
                {
                    for (int col = 0; col < squaresPerRow; col++)
                    {
                        // Determine color based on position
                        Color fillColor = ((row + col) % 2 == 0) ? Color.White : Color.Black;

                        // Create brush for the current square
                        using (SolidBrush brush = new SolidBrush(fillColor))
                        {
                            int x = col * squareSize;
                            int y = row * squareSize;
                            Rectangle rect = new Rectangle(x, y, squareSize, squareSize);
                            graphics.FillRectangle(brush, rect);
                        }
                    }
                }

                // Save the bound image
                canvas.Save();
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
 * 1. When a developer needs to generate a 24‑bit BMP file that serves as a test pattern for calibrating image scanners or printers, they can use this code to draw an 8×8 checkerboard of alternating black and white squares.
 * 2. When creating placeholder graphics for a game board or UI layout where the assets must be stored as BMP images, this method quickly produces a tiled checkerboard background using Aspose.Imaging’s RasterImage and Graphics classes.
 * 3. When writing automated unit tests for image‑processing pipelines, a developer can employ this snippet to produce a known BMP pattern that can be compared against expected pixel values.
 * 4. When building a desktop application that exports printable board‑game templates in BMP format, the code provides a simple way to render the alternating squares with solid brushes and save them directly to disk.
 * 5. When needing to generate a high‑contrast reference image for computer‑vision algorithms that detect edges or patterns, the checkerboard BMP created by this method offers a reliable input for training or debugging.
 */