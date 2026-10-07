// HOW-TO: Create 500x300 BMP Image and Draw Blue Line in C# (Aspose.Imaging for .NET)
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
            BmpOptions options = new BmpOptions() { Source = source };

            using (RasterImage canvas = (RasterImage)Image.Create(options, 500, 300))
            {
                Graphics graphics = new Graphics(canvas);
                Pen pen = new Pen(Color.Blue, 1);
                graphics.DrawLine(pen, new Point(50, 50), new Point(450, 250));
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
 * 1. When you need to generate a simple BMP placeholder with a custom line for UI mockups.
 * 2. When you want to programmatically add a guide line to a bitmap for image analysis preprocessing.
 * 3. When creating a test pattern for hardware that only accepts BMP files and requires a colored line.
 * 4. When automating the production of diagrammatic assets, such as a baseline line in a chart, using C#.
 * 5. When building a graphics utility that draws vector shapes onto raster BMP canvases for legacy systems.
 */
