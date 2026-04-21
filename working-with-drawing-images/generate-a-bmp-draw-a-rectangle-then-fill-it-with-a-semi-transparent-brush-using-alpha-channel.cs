using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new BMP image
        using (Image image = Image.Create(bmpOptions, 400, 300))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Optional: clear background
            graphics.Clear(Color.White);

            // Define rectangle bounds
            Rectangle rect = new Rectangle(50, 50, 200, 150);

            // Draw rectangle outline
            graphics.DrawRectangle(new Pen(Color.Black, 2), rect);

            // Fill rectangle with a semi‑transparent brush
            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                brush.Opacity = 0.5f; // 50% opacity
                graphics.FillRectangle(brush, rect);
            }

            // Save the image (output path already bound)
            image.Save();
        }
    }
}