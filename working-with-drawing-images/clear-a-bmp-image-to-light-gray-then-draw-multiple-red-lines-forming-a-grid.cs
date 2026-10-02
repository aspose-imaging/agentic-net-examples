// HOW-TO: Create Light Gray BMP with Red Grid Lines in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 500;
            int height = 500;
            int gridSpacing = 50;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);

                Pen redPen = new Pen(Color.Red, 1);

                for (int x = 0; x <= width; x += gridSpacing)
                {
                    graphics.DrawLine(redPen, new Point(x, 0), new Point(x, height));
                }

                for (int y = 0; y <= height; y += gridSpacing)
                {
                    graphics.DrawLine(redPen, new Point(0, y), new Point(width, y));
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
 * 1. When you need to generate a blank BMP canvas with a light gray background for a UI mockup and overlay a red grid to align elements.
 * 2. When creating printable graph paper or engineering drawing templates programmatically in C# using Aspose.Imaging.
 * 3. When preparing a background image for a game level editor where a colored grid helps designers position objects.
 * 4. When automating the production of test images that show a consistent pattern for image processing algorithm validation.
 * 5. When building a simple diagramming tool that requires a BMP file with a colored grid as the base layer for drawing shapes.
 */
