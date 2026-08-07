using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };
            int width = 500;
            int height = 500;

            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.Navy);
                Pen whitePen = new Pen(Color.White, 1);
                graphics.DrawLine(whitePen, new Point(0, 0), new Point(width, height));
                graphics.DrawLine(whitePen, new Point(0, height), new Point(width, 0));
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
 * 1. When a developer needs to generate a BMP placeholder image with a navy background and a white diagonal cross for testing image loading in a .NET application.
 * 2. When an automated report generator must create a simple watermark or marker image in BMP format using C# and Aspose.Imaging to overlay on scanned documents.
 * 3. When a game developer wants to programmatically produce a 500×500 pixel texture with a navy base color and white cross lines for use as a UI icon or flag in a Unity project.
 * 4. When a batch image processing script requires creating a blank BMP canvas, clearing it to a specific color, and drawing geometric lines to serve as a template for later annotation.
 * 5. When a documentation tool needs to dynamically generate a sample BMP file that demonstrates basic raster graphics operations like clearing, drawing lines, and saving with Aspose.Imaging in C#.
 */