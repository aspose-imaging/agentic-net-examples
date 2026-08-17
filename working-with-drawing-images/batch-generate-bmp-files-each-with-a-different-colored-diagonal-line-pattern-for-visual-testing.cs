// HOW-TO: Create Multiple BMP Images with Colored Diagonal Lines in C# (Aspose.Imaging for .NET)
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
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            Aspose.Imaging.Color[] colors = new Aspose.Imaging.Color[]
            {
                Aspose.Imaging.Color.Red,
                Aspose.Imaging.Color.Green,
                Aspose.Imaging.Color.Blue,
                Aspose.Imaging.Color.Yellow,
                Aspose.Imaging.Color.Magenta
            };

            int width = 200;
            int height = 200;

            for (int i = 0; i < colors.Length; i++)
            {
                string outputPath = Path.Combine(outputDir, $"diag_{i + 1}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                FileCreateSource source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };

                using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(options, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(colors[i], 5);
                    graphics.DrawLine(pen, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Point(width - 1, height - 1));

                    canvas.Save();
                }
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
 * 1. When you need to generate a set of BMP test images with distinct colored diagonal lines to verify rendering pipelines in a graphics application.
 * 2. When creating placeholder assets for UI mockups that require simple color‑coded diagonal patterns for layout testing.
 * 3. When automating visual regression tests that compare generated BMP files against baseline images to detect changes in drawing code.
 * 4. When preparing sample images for documentation or tutorials that demonstrate how to draw lines using Aspose.Imaging in C#.
 * 5. When building a batch process that produces color‑coded diagnostic images for hardware calibration or printer testing.
 */
