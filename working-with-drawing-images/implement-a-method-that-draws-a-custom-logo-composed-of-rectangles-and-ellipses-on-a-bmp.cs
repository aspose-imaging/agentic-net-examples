// HOW-TO: Create a BMP Logo with Rectangles and Ellipses in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/logo.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Fill background rectangle
                using (SolidBrush backgroundBrush = new SolidBrush(Aspose.Imaging.Color.LightGray))
                {
                    graphics.FillRectangle(backgroundBrush, new Rectangle(20, 20, 160, 160));
                }

                // Outline rectangle
                Pen rectPen = new Pen(Aspose.Imaging.Color.Blue, 3);
                graphics.DrawRectangle(rectPen, new Rectangle(20, 20, 160, 160));

                // Fill ellipse
                using (SolidBrush ellipseBrush = new SolidBrush(Aspose.Imaging.Color.Yellow))
                {
                    graphics.FillEllipse(ellipseBrush, new Rectangle(50, 50, 100, 100));
                }

                // Outline ellipse
                Pen ellipsePen = new Pen(Aspose.Imaging.Color.Red, 2);
                graphics.DrawEllipse(ellipsePen, new Rectangle(50, 50, 100, 100));

                // Save the image (output path already bound)
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
 * 1. When you need to generate a simple company badge or icon as a BMP file by programmatically drawing shapes with Aspose.Imaging in C#.
 * 2. When you want to create placeholder graphics for UI prototypes that require rectangles and ellipses without using external design tools.
 * 3. When an automated report generator must embed a custom logo into a BMP image using .NET drawing APIs.
 * 4. When a batch process has to produce multiple stamped images with consistent geometric branding elements for a Windows application.
 * 5. When you are testing image processing pipelines and require a known BMP file containing specific colored shapes for validation.
 */
