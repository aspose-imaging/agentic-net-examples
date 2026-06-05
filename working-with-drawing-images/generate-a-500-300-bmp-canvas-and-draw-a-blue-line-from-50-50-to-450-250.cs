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
            string outputPath = @"C:\temp\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            FileCreateSource source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(options, 500, 300))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.DrawLine(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 1), 50, 50, 450, 250);
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
 * 1. When a developer needs to create a simple BMP placeholder image with a diagonal blue line for testing image rendering pipelines in a .NET application.
 * 2. When generating a custom watermark or annotation on a bitmap file, such as drawing a blue guide line on a 500×300 BMP before embedding it into a PDF.
 * 3. When building a diagnostic tool that visualizes coordinate transformations by programmatically drawing lines on a raster image using Aspose.Imaging in C#.
 * 4. When preparing sample graphics for a UI mock‑up where a blue line on a BMP canvas demonstrates line‑drawing capabilities of a graphics library.
 * 5. When automating the creation of batch‑processed BMP assets for a game’s level editor, requiring a blue line to indicate a path or boundary on each generated image.
 */