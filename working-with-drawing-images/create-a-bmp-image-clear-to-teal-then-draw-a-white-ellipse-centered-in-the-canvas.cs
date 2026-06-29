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

            Aspose.Imaging.Sources.FileCreateSource source = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            int width = 500;
            int height = 500;

            using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(options, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.Teal);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.White, 2);
                int ellipseSize = 300;
                Aspose.Imaging.Rectangle ellipseRect = new Aspose.Imaging.Rectangle(
                    (width - ellipseSize) / 2,
                    (height - ellipseSize) / 2,
                    ellipseSize,
                    ellipseSize);

                graphics.DrawEllipse(pen, ellipseRect);
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
 * 1. When a developer needs to generate a BMP placeholder image with a solid teal background and a centered white ellipse for UI mockups or testing image loading pipelines.
 * 2. When an application must programmatically create a 500×500 bitmap file for a game asset, using Aspose.Imaging to clear the canvas to teal and draw a white ellipse as a simple sprite.
 * 3. When a reporting tool requires dynamic generation of BMP charts where the background color is teal and a white ellipse represents a data point or highlight.
 * 4. When a batch process creates thumbnail previews for scanned documents, and the developer wants to add a teal backdrop with a white ellipse watermark using C# and Aspose.Imaging.
 * 5. When an automated test suite validates image processing functions by producing a known BMP image with a teal fill and a centered white ellipse to compare against expected results.
 */