// HOW-TO: Create a 200x200 BMP with Teal Background and White Ellipse in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output\\image.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;

            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.BitsPerPixel = 32;

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.Teal);

                    int ellipseWidth = width - 20;
                    int ellipseHeight = height - 20;
                    int x = (width - ellipseWidth) / 2;
                    int y = (height - ellipseHeight) / 2;

                    Pen pen = new Pen(Color.White);
                    graphics.DrawEllipse(pen, x, y, ellipseWidth, ellipseHeight);

                    image.Save(outputPath, bmpOptions);
                }
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
 * 1. When you need to generate a BMP icon with a solid teal background and a centered white ellipse for a desktop application's UI.
 * 2. When you want to programmatically create a simple placeholder image for testing image‑processing pipelines that require BMP format.
 * 3. When you need to produce a custom badge or logo in BMP format with a colored background and a circular highlight for embedding in reports.
 * 4. When you are building a game and require a bitmap sprite sheet where each sprite is a teal canvas with a white circular marker.
 * 5. When you need to automate the creation of BMP thumbnails with a consistent teal theme and an ellipse overlay for batch processing.
 */
