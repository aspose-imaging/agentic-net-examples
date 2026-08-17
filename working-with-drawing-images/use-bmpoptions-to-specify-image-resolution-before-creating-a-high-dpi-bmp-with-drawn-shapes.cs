// HOW-TO: Create High DPI BMP with Custom Resolution and Draw Shapes in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\Temp\highdpi_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options with high DPI (e.g., 300)
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Compression = BitmapCompression.Rgb,
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 200x200 BMP image using the options
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Obtain a graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Fill the background with light gray
                SolidBrush backgroundBrush = new SolidBrush(Color.LightGray);
                graphics.FillRectangle(backgroundBrush, image.Bounds);

                // Draw a red ellipse
                SolidBrush redBrush = new SolidBrush(Color.Red);
                graphics.FillEllipse(redBrush, new Rectangle(20, 20, 160, 160));

                // Draw a blue rectangle
                SolidBrush blueBrush = new SolidBrush(Color.Blue);
                graphics.FillRectangle(blueBrush, new Rectangle(50, 150, 100, 30));

                // Save the image (FileCreateSource handles the file path)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a print‑ready 300 DPI BMP file programmatically for high‑quality brochures or flyers.
 * 2. When you must embed vector‑like graphics such as ellipses and rectangles into a BMP for use in legacy Windows applications.
 * 3. When an automated reporting tool has to produce high‑resolution bitmap charts that match a specific DPI setting.
 * 4. When a desktop utility creates thumbnails or watermarked BMP images while preserving the original resolution for downstream processing.
 * 5. When a batch conversion service needs to set the DPI of BMP files before saving them to a network share for archival purposes.
 */
