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
            string outputPath = "output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            using (RasterImage canvas = (RasterImage)Image.Create(options, 500, 300))
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
 * 1. When a developer needs to generate a 500 × 300 BMP image with a custom blue line for a simple diagram in a Windows desktop application using Aspose.Imaging for .NET.
 * 2. When an automated reporting tool must create a bitmap thumbnail that includes a slanted blue line to indicate trend direction, leveraging C# Graphics.DrawLine on a RasterImage canvas.
 * 3. When a game developer wants to produce a static background BMP asset with a blue line as a visual guide for level design, using Aspose.Imaging's BmpOptions and Pen objects.
 * 4. When a document conversion service has to embed a blue line annotation into a BMP file before embedding it into a PDF, employing Aspose.Imaging's Image.Create and Graphics.DrawLine methods.
 * 5. When a testing framework requires a deterministic BMP file containing a known blue line to validate image processing algorithms that read line geometry from bitmap data.
 */