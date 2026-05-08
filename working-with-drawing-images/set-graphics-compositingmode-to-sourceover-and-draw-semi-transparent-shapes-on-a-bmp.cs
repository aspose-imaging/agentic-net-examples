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
            // Output BMP path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            bmpOptions.BitsPerPixel = 32; // Enable alpha channel

            // Create a 500x400 BMP image bound to the output file
            using (Image image = Image.Create(bmpOptions, 500, 400))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.White);

                // Draw semi‑transparent red rectangle
                using (SolidBrush redBrush = new SolidBrush())
                {
                    redBrush.Color = Color.FromArgb(128, 255, 0, 0); // 50% opacity
                    redBrush.Opacity = 0.5f;
                    graphics.FillRectangle(redBrush, new Rectangle(50, 50, 200, 150));
                }

                // Draw semi‑transparent green ellipse
                using (SolidBrush greenBrush = new SolidBrush())
                {
                    greenBrush.Color = Color.FromArgb(128, 0, 255, 0);
                    greenBrush.Opacity = 0.5f;
                    graphics.FillEllipse(greenBrush, new Rectangle(150, 120, 200, 150));
                }

                // Draw semi‑transparent blue polygon
                using (SolidBrush blueBrush = new SolidBrush())
                {
                    blueBrush.Color = Color.FromArgb(128, 0, 0, 255);
                    blueBrush.Opacity = 0.5f;
                    Point[] points = new Point[]
                    {
                        new Point(300, 50),
                        new Point(400, 200),
                        new Point(250, 300),
                        new Point(150, 200)
                    };
                    graphics.FillPolygon(blueBrush, points);
                }

                // Save the bound image
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}