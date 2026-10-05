// HOW-TO: Draw a Smooth S-Shaped Bezier Curve on a BMP in C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 250;
            int height = 200;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);

                Aspose.Imaging.PointF p1 = new Aspose.Imaging.PointF(10, 100);
                Aspose.Imaging.PointF p2 = new Aspose.Imaging.PointF(50, 10);
                Aspose.Imaging.PointF p3 = new Aspose.Imaging.PointF(150, 190);
                Aspose.Imaging.PointF p4 = new Aspose.Imaging.PointF(200, 100);

                graphics.DrawBezier(pen, p1, p2, p3, p4);

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
 * 1. When you need to programmatically generate a BMP file that contains a smooth S‑shaped curve for custom UI graphics or diagram annotations in a .NET application.
 * 2. When you want to create vector‑like drawing primitives such as Bezier curves on raster images for generating test patterns or sample images in automated image‑processing pipelines.
 * 3. When you must render a scalable smooth curve onto a BMP to embed in reports, PDFs, or email attachments without relying on external graphic editors.
 * 4. When you are building a signature or handwriting simulation that requires precise control points using PointF and need to output the result as a BMP for legacy systems.
 * 5. When you need to demonstrate or benchmark Aspose.Imaging’s Graphics.DrawBezier method by drawing a curved path on a bitmap and saving it with specific pen color and thickness.
 */
