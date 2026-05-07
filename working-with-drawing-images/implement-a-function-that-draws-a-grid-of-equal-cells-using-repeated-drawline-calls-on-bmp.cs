using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output_grid.bmp";

        try
        {
            // Verify input file existence (not used further, but required by the safety rules)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions and grid settings
            int imageWidth = 500;
            int imageHeight = 500;
            int rows = 10;
            int cols = 10;
            int cellWidth = imageWidth / cols;
            int cellHeight = imageHeight / rows;

            // Create a new BMP image
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };
            using (Image image = Image.Create(bmpOptions, imageWidth, imageHeight))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Pen for drawing grid lines
                Pen pen = new Pen(Color.Black, 1);

                // Draw vertical grid lines
                for (int c = 0; c <= cols; c++)
                {
                    int x = c * cellWidth;
                    graphics.DrawLine(pen, x, 0, x, imageHeight);
                }

                // Draw horizontal grid lines
                for (int r = 0; r <= rows; r++)
                {
                    int y = r * cellHeight;
                    graphics.DrawLine(pen, 0, y, imageWidth, y);
                }

                // Save the resulting image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}