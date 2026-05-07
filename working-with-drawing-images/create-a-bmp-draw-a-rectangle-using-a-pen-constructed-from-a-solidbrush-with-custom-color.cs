using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

namespace AsposeImagingExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded output path
                string outputPath = @"C:\Temp\output.bmp";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create a new BMP image (200x200 pixels, 24 bits per pixel)
                var bmpOptions = new BmpOptions();
                using (Image image = Image.Create(bmpOptions, 200, 200))
                {
                    // Initialize graphics object for drawing
                    var graphics = new Graphics(image);

                    // Create a SolidBrush with a custom orange color
                    var brush = new SolidBrush(Color.FromArgb(255, 255, 165, 0)); // Orange

                    // Create a Pen from the SolidBrush with a width of 3 pixels
                    var pen = new Pen(brush, 3);

                    // Draw a rectangle at position (20,20) with size 160x160
                    graphics.DrawRectangle(pen, 20, 20, 160, 160);

                    // Save the BMP image to the specified path
                    image.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}