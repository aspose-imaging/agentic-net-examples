using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 200;
            int height = 200;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawLine(pen, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Point(width, height));

                graphics.ScaleTransform(-1, 1);
                graphics.TranslateTransform(-width, 0);

                graphics.DrawLine(pen, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Point(width, height));

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
 * 1. When a developer needs to generate a BMP image with a diagonal line and its mirrored counterpart for a document preview watermark using Aspose.Imaging and C#.
 * 2. When creating a simple test pattern in a .NET console application to validate that Graphics.ScaleTransform correctly flips graphics horizontally in a BMP file.
 * 3. When building a batch process that adds symmetric diagonal lines to product label images saved as BMP format for visual consistency across a catalog.
 * 4. When developing a diagnostic tool that visualizes coordinate transformations by drawing an original and a mirrored diagonal line in the same bitmap using Aspose.Imaging.Graphics.
 * 5. When implementing a lightweight graphics routine to produce mirrored line art for educational tutorials on image processing concepts such as scaling and translation in C#.
 */