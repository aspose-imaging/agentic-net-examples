using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Create the overlay position point
                Point overlayPosition = new Point(100, 200);

                // Create a graphics object for drawing
                Graphics graphics = new Graphics(tiffImage);

                // Draw a red rectangle at the specified point
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    Rectangle rect = new Rectangle(overlayPosition.X, overlayPosition.Y, 50, 50);
                    graphics.FillRectangle(brush, rect);
                }

                // Save the modified image
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}