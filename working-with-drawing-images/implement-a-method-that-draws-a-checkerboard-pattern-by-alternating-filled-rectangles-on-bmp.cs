using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = "output/checkerboard.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define image dimensions and checkerboard parameters
        int imageWidth = 400;
        int imageHeight = 400;
        int cellSize = 50; // size of each square

        // Set up BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, imageWidth, imageHeight))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Prepare brushes for the two colors
            using (SolidBrush blackBrush = new SolidBrush(Color.Black))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            {
                // Loop through rows and columns to draw squares
                for (int y = 0; y < imageHeight; y += cellSize)
                {
                    for (int x = 0; x < imageWidth; x += cellSize)
                    {
                        // Choose brush based on position parity
                        SolidBrush brush = ((x / cellSize) + (y / cellSize)) % 2 == 0 ? blackBrush : whiteBrush;

                        // Define rectangle for the current cell
                        Rectangle rect = new Rectangle(x, y, cellSize, cellSize);

                        // Fill the rectangle
                        graphics.FillRectangle(brush, rect);
                    }
                }
            }

            // Save the image (output is already bound to the file)
            image.Save();
        }
    }
}