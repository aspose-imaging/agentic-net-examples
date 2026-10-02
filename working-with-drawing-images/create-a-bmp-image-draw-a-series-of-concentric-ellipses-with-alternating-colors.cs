// HOW-TO: Create BMP with Concentric Colored Ellipses Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 500;
            int height = 500;

            var bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                int ellipseCount = 10;
                int step = Math.Min(width, height) / (ellipseCount * 2);

                for (int i = 0; i < ellipseCount; i++)
                {
                    int offset = i * step;
                    int ellipseWidth = width - 2 * offset;
                    int ellipseHeight = height - 2 * offset;
                    var rect = new RectangleF(offset, offset, ellipseWidth, ellipseHeight);
                    Color penColor = (i % 2 == 0) ? Color.Red : Color.Blue;

                    Pen pen = new Pen(penColor, 3);
                    graphics.DrawEllipse(pen, rect);
                }

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
 * 1. When you need to generate a BMP file that visualizes nested shapes for a UI mock‑up or diagram, this code draws concentric ellipses with alternating red and blue outlines.
 * 2. When creating test images to verify image‑processing algorithms that handle vector drawing and color strokes, the example produces a predictable pattern of circles in a BMP.
 * 3. When producing simple background graphics for a Windows Forms application, you can use this code to programmatically render layered ellipses without external design tools.
 * 4. When automating the creation of printable assets such as badge frames or decorative borders, the script generates a high‑resolution BMP with alternating colored rings.
 * 5. When benchmarking the performance of Aspose.Imaging’s Graphics API for drawing operations, the loop of ten ellipses provides a repeatable workload.
 */
