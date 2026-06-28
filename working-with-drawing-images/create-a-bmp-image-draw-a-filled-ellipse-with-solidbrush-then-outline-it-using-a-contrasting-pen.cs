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
        string outputPath = @"c:\temp\ellipse.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillEllipse(brush, new Rectangle(50, 50, 300, 200));
                }

                Pen pen = new Pen(Color.Black, 3);
                graphics.DrawEllipse(pen, new Rectangle(50, 50, 300, 200));

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
 * 1. When a developer needs to generate a 24‑bit BMP thumbnail that features a blue filled ellipse with a black outline for a Windows desktop widget.
 * 2. When an application must programmatically create a BMP badge containing a centered ellipse using Aspose.Imaging’s SolidBrush and Pen classes for a game UI.
 * 3. When a reporting tool requires drawing highlighted elliptical regions on a BMP chart to emphasize data points by filling and outlining the shape.
 * 4. When a batch process creates printable BMP stamps with a solid colored ellipse and contrasting border for branding on physical documents.
 * 5. When a legacy system expects a BMP image with a simple vector shape—such as a filled ellipse outlined with a pen—to be embedded in an email attachment.
 */