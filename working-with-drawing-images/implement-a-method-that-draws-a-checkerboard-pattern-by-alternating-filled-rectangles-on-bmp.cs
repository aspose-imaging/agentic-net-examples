// HOW-TO: Create a Checkerboard BMP Image with Alternating Black Squares in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "checkerboard.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int rows = 8;
            int cols = 8;
            int squareSize = 50;
            int width = cols * squareSize;
            int height = rows * squareSize;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        if ((x + y) % 2 == 0)
                        {
                            using (SolidBrush brush = new SolidBrush(Color.Black))
                            {
                                graphics.FillRectangle(brush, x * squareSize, y * squareSize, squareSize, squareSize);
                            }
                        }
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
 * 1. When you need to generate a printable chessboard pattern for a game board mock‑up as a BMP file using C#.
 * 2. When you want to create a high‑contrast test image for calibrating image‑processing algorithms that require alternating black and white squares.
 * 3. When you are building a UI component that displays a tiled background and need to produce the pattern programmatically without external assets.
 * 4. When you need to produce a BMP sprite sheet for a retro‑style game where each tile is a solid color square.
 * 5. When you are automating the creation of sample images for documentation or unit tests that demonstrate drawing operations with Aspose.Imaging.
 */
