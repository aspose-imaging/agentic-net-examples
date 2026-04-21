using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Collection of size specifications: width, height, and square side length
        var specifications = new (int width, int height, int squareSize)[]
        {
            (200, 200, 100),
            (300, 150, 80),
            (400, 300, 150)
        };

        // Output directory
        string outputDirectory = "Output";
        Directory.CreateDirectory(outputDirectory);

        foreach (var spec in specifications)
        {
            int width = spec.width;
            int height = spec.height;
            int square = spec.squareSize;

            // Ensure the square fits within the image bounds
            if (square > width) square = width;
            if (square > height) square = height;

            // Output file path
            string outputPath = Path.Combine(outputDirectory, $"image_{width}x{height}.bmp");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a file source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions
            {
                Source = source,
                BitsPerPixel = 24
            };

            // Create a BMP canvas
            using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, width, height))
            {
                // Fill background with white
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Calculate centered square position
                int offsetX = (width - square) / 2;
                int offsetY = (height - square) / 2;

                // Draw the centered square in red
                using (SolidBrush squareBrush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(squareBrush, new Rectangle(offsetX, offsetY, square, square));
                }

                // Save the bound image
                canvas.Save();
            }
        }
    }
}