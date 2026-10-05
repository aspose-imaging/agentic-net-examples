// HOW-TO: Create BMP With Shapes And Set Compression Level In C# (Aspose.Imaging for .NET)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions()
            {
                Source = source
            };

            int width = 200;
            int height = 150;

            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen, new Rectangle(20, 20, 160, 110));
                graphics.DrawEllipse(pen, new Rectangle(50, 40, 100, 70));
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
 * 1. When you need to generate a BMP file that contains custom graphics such as rectangles or ellipses while controlling file size through compression.
 * 2. When an application must programmatically create thumbnails or overlays for legacy BMP assets and ensure they meet specific storage constraints.
 * 3. When a Windows desktop tool requires drawing vector shapes onto a bitmap and saving it with a chosen compression level for faster loading.
 * 4. When automating batch processing of reports that embed simple diagrams into BMP images and you want to reduce disk usage without losing shape fidelity.
 * 5. When integrating Aspose.Imaging into a C# service that produces BMP images on the fly for printing or archival purposes and you must specify compression to comply with size limits.
 */
