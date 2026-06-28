using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawLine(pen, new Point(10, 10), new Point(190, 10));

                graphics.ScaleTransform(2f, 1f);
                graphics.DrawLine(pen, new Point(10, 30), new Point(190, 30));

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
 * 1. When a developer needs to generate a BMP diagram with a double‑length line for a quick visual guide in a Windows desktop application, this code provides a simple way to draw and scale the line using Aspose.Imaging for .NET.
 * 2. When a C# backend must create a BMP image that illustrates measurement units with a stretched line for inclusion in a technical report, the code demonstrates how to apply Graphics.ScaleTransform to double the line’s length.
 * 3. When an automated email system requires a BMP banner where the second line is horizontally scaled to emphasize a header, this example shows how to draw and scale the line before saving the image.
 * 4. When building unit tests for graphics transformations in an Aspose.Imaging image‑processing pipeline, developers can use this code to produce a test BMP with a scaled line to verify the ScaleTransform behavior.
 * 5. When exporting a BMP sprite sheet and needing to preview how a line appears after horizontal scaling before integrating it into a game engine, this snippet creates the image and applies the scaling transformation.
 */