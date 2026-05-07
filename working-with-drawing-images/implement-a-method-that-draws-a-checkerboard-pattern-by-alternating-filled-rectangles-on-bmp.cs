using System;
using System.IO;
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
            // Output file path (hardcoded)
            string outputPath = @"C:\temp\checkerboard.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a file source
            FileCreateSource source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            // Define canvas size
            int width = 400;
            int height = 400;

            // Create a BMP canvas bound to the output file
            using (BmpImage canvas = (BmpImage)Aspose.Imaging.Image.Create(options, width, height))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);

                // Checkerboard parameters
                int tileSize = 50;
                int rows = height / tileSize;
                int cols = width / tileSize;

                // Prepare brushes
                using (SolidBrush blackBrush = new SolidBrush(Aspose.Imaging.Color.Black))
                using (SolidBrush whiteBrush = new SolidBrush(Aspose.Imaging.Color.White))
                {
                    for (int y = 0; y < rows; y++)
                    {
                        for (int x = 0; x < cols; x++)
                        {
                            SolidBrush brush = ((x + y) % 2 == 0) ? blackBrush : whiteBrush;
                            int posX = x * tileSize;
                            int posY = y * tileSize;

                            // Fill the rectangle tile
                            graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(posX, posY, tileSize, tileSize));
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