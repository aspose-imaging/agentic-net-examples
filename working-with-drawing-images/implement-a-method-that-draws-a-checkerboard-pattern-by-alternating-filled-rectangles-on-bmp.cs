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
        // Output BMP file path
        string outputPath = @"C:\temp\checkerboard.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Image dimensions and checkerboard settings
        int width = 400;
        int height = 400;
        int squaresPerSide = 8;
        int squareSize = width / squaresPerSide;

        // Configure BMP options with FileCreateSource
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Create graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Draw checkerboard squares
            for (int row = 0; row < squaresPerSide; row++)
            {
                for (int col = 0; col < squaresPerSide; col++)
                {
                    int x = col * squareSize;
                    int y = row * squareSize;
                    Aspose.Imaging.Color fillColor = ((row + col) % 2 == 0) ? Aspose.Imaging.Color.White : Aspose.Imaging.Color.Black;

                    using (SolidBrush brush = new SolidBrush(fillColor))
                    {
                        graphics.FillRectangle(brush, new Rectangle(x, y, squareSize, squareSize));
                    }
                }
            }

            // Save the image (output path already bound via FileCreateSource)
            image.Save();
        }
    }
}