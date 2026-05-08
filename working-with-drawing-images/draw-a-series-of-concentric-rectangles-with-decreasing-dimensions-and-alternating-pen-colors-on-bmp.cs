using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\concentric_rectangles.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false)
            };

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw concentric rectangles
                int rectCount = 10;
                int marginStep = 20;
                for (int i = 0; i < rectCount; i++)
                {
                    int margin = i * marginStep;
                    int size = 500 - 2 * margin;
                    if (size <= 0) break;

                    // Alternate pen colors
                    Color penColor = (i % 2 == 0) ? Color.Red : Color.Blue;
                    Pen pen = new Pen(penColor, 3f);

                    graphics.DrawRectangle(pen, margin, margin, size, size);
                }

                // Save the image
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}