using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\vertical_lines.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions
            int width = 500;
            int height = 500;
            int lineCount = 10;
            int spacing = width / (lineCount + 1); // equal spacing between lines

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new BMP image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Thin black pen (1 pixel width)
                Pen pen = new Pen(Color.Black, 1);

                // Draw vertical lines
                for (int i = 1; i <= lineCount; i++)
                {
                    int x = i * spacing;
                    graphics.DrawLine(pen, x, 0, x, height);
                }

                // Save the image (writes to the FileCreateSource path)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}