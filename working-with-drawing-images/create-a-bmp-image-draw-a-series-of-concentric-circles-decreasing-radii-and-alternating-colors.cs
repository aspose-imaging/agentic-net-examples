using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"c:\temp\concentric_circles.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                int centerX = width / 2;
                int centerY = height / 2;

                int maxRadius = Math.Min(width, height) / 2 - 10;
                int step = 20;
                bool useRed = true;

                for (int radius = maxRadius; radius > 0; radius -= step)
                {
                    Color penColor = useRed ? Color.Red : Color.Blue;
                    Pen pen = new Pen(penColor, 3);
                    int left = centerX - radius;
                    int top = centerY - radius;
                    int diameter = radius * 2;
                    graphics.DrawEllipse(pen, new Aspose.Imaging.Rectangle(left, top, diameter, diameter));
                    useRed = !useRed;
                }

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
 * 1. When a developer needs to programmatically generate a 24‑bit BMP file with concentric circles for UI placeholders or to test the Aspose.Imaging rendering pipeline.
 * 2. When creating calibration patterns for printers or displays, using alternating red and blue circles drawn with Aspose.Imaging’s Graphics.DrawEllipse to verify color accuracy.
 * 3. When producing educational graphics that illustrate geometric concepts such as radius, diameter, and center point, saved directly as a BMP image via C#.
 * 4. When automating the creation of simple circular icons or badges without manual design tools, leveraging Aspose.Imaging’s Pen and Rectangle classes.
 * 5. When generating test images to benchmark the performance of Aspose.Imaging’s drawing operations (e.g., DrawEllipse) in a .NET application.
 */