using System;
using System.IO;
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

            FileCreateSource source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            using (BmpImage canvas = (BmpImage)Aspose.Imaging.Image.Create(options, 200, 200))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.DarkGray);
                graphics.DrawLine(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Yellow, 2),
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(200, 200));

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
 * 1. When generating a simple placeholder image for a Windows desktop application, a developer can use this code to create a 200×200 BMP file with a dark‑gray background and a bright yellow diagonal line.
 * 2. When automating the production of test assets for image‑processing unit tests, this snippet quickly creates a BMP image that contains a known pattern (dark gray canvas with a yellow line) for validation.
 * 3. When building a batch script that adds a visual watermark to a set of BMP icons, a developer can employ this code to draw a high‑contrast yellow diagonal line on a dark background as the watermark.
 * 4. When creating a custom cursor or pointer graphic for a .NET game, the code demonstrates how to programmatically generate a BMP file with a dark gray base and a bright yellow diagonal line to indicate direction.
 * 5. When developing a reporting tool that needs to embed a simple diagram into a BMP file, this example shows how to clear the canvas to dark gray and draw a yellow line to represent a trend line.
 */