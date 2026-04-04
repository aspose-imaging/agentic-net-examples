using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Output directory (hardcoded)
        string outputDirectory = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Collection of size specifications: (canvas size, square size)
        var specs = new List<(int canvasSize, int squareSize)>
        {
            (200, 100),
            (300, 150),
            (400, 200)
        };

        foreach (var spec in specs)
        {
            int canvasSize = spec.canvasSize;
            int squareSize = spec.squareSize;

            // Build output file path
            string outputPath = Path.Combine(outputDirectory, $"square_{canvasSize}.bmp");

            // Ensure the directory for the output file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with bound file source
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create the canvas image (bound to the output file)
            using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, canvasSize, canvasSize))
            {
                // Draw a centered square
                Graphics graphics = new Graphics(canvas);
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    int offset = (canvasSize - squareSize) / 2;
                    Rectangle rect = new Rectangle(offset, offset, squareSize, squareSize);
                    graphics.FillRectangle(brush, rect);
                }

                // Save the bound image
                canvas.Save();
            }
        }
    }
}