using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = @"C:\Temp\logo.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.White);

                // Draw outer rectangle
                Pen rectPen = new Pen(Color.Black, 3);
                graphics.DrawRectangle(rectPen, 50, 50, 300, 300);

                // Fill first ellipse
                using (SolidBrush blueBrush = new SolidBrush())
                {
                    blueBrush.Color = Color.Blue;
                    blueBrush.Opacity = 100;
                    graphics.FillEllipse(blueBrush, new Rectangle(100, 100, 200, 200));
                }

                // Fill second ellipse with a different color
                using (SolidBrush redBrush = new SolidBrush())
                {
                    redBrush.Color = Color.Red;
                    redBrush.Opacity = 80;
                    graphics.FillEllipse(redBrush, new Rectangle(150, 150, 100, 100));
                }

                // Save the image (file is already bound to the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}