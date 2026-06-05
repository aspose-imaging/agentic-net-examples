using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\border.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            int width = 500;
            int height = 500;

            using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(options, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 10);
                graphics.DrawRectangle(pen, 0, 0, canvas.Width, canvas.Height);
                canvas.Save();
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
 * 1. When a developer needs to generate a BMP image with a thick red border to use as a highlighted thumbnail in a Windows desktop application that displays image previews.
 * 2. When an automated reporting tool must add a visible red frame to BMP charts before embedding them into PDF documents for visual emphasis.
 * 3. When a batch image processing script creates BMP assets with a red outline to mark UI components in a game development pipeline using Aspose.Imaging for C#.
 * 4. When a legacy manufacturing system requires BMP files with a colored border for printing labels on industrial printers that only accept the BMP format.
 * 5. When a diagnostic utility draws a thick red border around a BMP screenshot to indicate error regions during automated UI testing.
 */