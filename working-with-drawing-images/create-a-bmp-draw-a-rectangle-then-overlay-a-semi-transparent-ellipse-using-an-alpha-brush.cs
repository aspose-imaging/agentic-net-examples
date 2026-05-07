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
        try
        {
            // Output BMP file path
            string outputPath = @"c:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Draw a blue rectangle
                Pen rectPen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(rectPen, new Rectangle(50, 50, 400, 400));

                // Overlay a semi‑transparent red ellipse
                using (SolidBrush ellipseBrush = new SolidBrush(Color.Red))
                {
                    ellipseBrush.Opacity = 0.5f; // 50% opacity
                    graphics.FillEllipse(ellipseBrush, new Rectangle(100, 100, 300, 300));
                }

                // Save the image to the specified BMP file
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}