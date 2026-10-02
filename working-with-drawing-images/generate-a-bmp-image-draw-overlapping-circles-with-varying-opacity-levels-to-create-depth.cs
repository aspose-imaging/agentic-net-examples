// HOW-TO: Create BMP with Overlapping Semi-Transparent Circles in C# (Aspose.Imaging for .NET)
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
        try
        {
            string outputPath = "output/circles.bmp";
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = ".";
            Directory.CreateDirectory(outputDir);

            int width = 400;
            int height = 400;

            var bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.Yellow);

                var brush1 = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
                graphics.FillEllipse(brush1, new Rectangle(50, 50, 200, 200));

                var brush2 = new SolidBrush(Color.FromArgb(128, 0, 255, 0));
                graphics.FillEllipse(brush2, new Rectangle(150, 100, 200, 200));

                var brush3 = new SolidBrush(Color.FromArgb(128, 0, 0, 255));
                graphics.FillEllipse(brush3, new Rectangle(100, 150, 200, 200));

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
 * 1. When you need to generate a BMP file that visualizes layered data using semi‑transparent circles for a dashboard or report.
 * 2. When you want to programmatically create a background image with colored overlapping shapes for a game UI or splash screen.
 * 3. When you need to produce a test image that demonstrates alpha blending and opacity handling in Aspose.Imaging for unit testing.
 * 4. When you are building a custom chart that represents intersecting data sets with colored circles in a BMP format.
 * 5. When you want to automate the creation of decorative graphics, such as logos or icons, that require overlapping translucent circles.
 */
