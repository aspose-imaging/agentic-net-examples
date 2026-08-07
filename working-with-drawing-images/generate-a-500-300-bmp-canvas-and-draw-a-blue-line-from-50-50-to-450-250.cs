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
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 500, 300))
            {
                Graphics graphics = new Graphics(canvas);
                Pen pen = new Pen(Color.Blue, 1);
                graphics.DrawLine(pen, 50, 50, 450, 250);
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
 * 1. When a developer needs to generate a simple BMP diagram for a legacy Windows application that only accepts BMP files, they can use Aspose.Imaging for .NET to create a 500 × 300 canvas and draw a blue line as a visual guide.
 * 2. When building automated image‑processing unit tests, a developer can programmatically produce a BMP image with a known blue line from (50,50) to (450,250) to validate line‑detection algorithms.
 * 3. When exporting chart data to a printer that requires non‑compressed BMP format, a developer can use the C# code to create a 500 × 300 bitmap and draw a blue trend line for the report.
 * 4. When designing custom UI assets for embedded devices that only support BMP images, a developer can employ Aspose.Imaging to draw a blue line on a 500 × 300 canvas for icons or separators.
 * 5. When automating the creation of placeholder graphics for documentation or mock‑ups, the code can quickly generate a BMP file with a blue line to illustrate layout concepts without using external design tools.
 */