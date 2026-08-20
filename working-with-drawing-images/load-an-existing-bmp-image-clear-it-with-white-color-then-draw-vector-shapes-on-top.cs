// HOW-TO: How to Clear BMP and Draw Shapes with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"input.bmp";
        string outputPath = @"output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
                graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(50, 50, 200, 150));
                graphics.DrawEllipse(pen, new Aspose.Imaging.Rectangle(300, 100, 150, 150));
                graphics.DrawLine(pen, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Point(400, 300));

                FileCreateSource source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions { Source = source };
                image.Save(outputPath, options);
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
 * 1. When you need to programmatically erase the contents of an existing BMP file and replace it with a white background before adding new graphics.
 * 2. When you want to overlay vector shapes such as rectangles, ellipses, and lines onto a bitmap image for generating custom diagrams or UI mock‑ups in a C# application.
 * 3. When you are building a batch‑processing tool that loads multiple BMP files, clears them, and draws consistent branding elements like logos or borders.
 * 4. When you need to create a simple drawing canvas from an input BMP, draw shapes with a specific pen width and color, and save the result as a new BMP for further processing.
 * 5. When you are integrating Aspose.Imaging into a .NET service that modifies scanned BMP documents by adding annotation lines or highlight shapes.
 */
