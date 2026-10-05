// HOW-TO: Draw a Five‑Pointed Star on a BMP Image with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
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
            string outputPath = "output_star.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 500;
            int height = 500;
            int centerX = width / 2;
            int centerY = height / 2;
            int outerRadius = 200;
            int innerRadius = 80;
            int pointsCount = 5;

            // Prepare star points (outer and inner alternating)
            Point[] starPoints = new Point[pointsCount * 2];
            double angleStep = Math.PI / pointsCount;
            for (int i = 0; i < pointsCount * 2; i++)
            {
                double radius = (i % 2 == 0) ? outerRadius : innerRadius;
                double angle = i * angleStep - Math.PI / 2; // start at top
                int x = centerX + (int)(radius * Math.Cos(angle));
                int y = centerY + (int)(radius * Math.Sin(angle));
                starPoints[i] = new Point(x, y);
            }

            BmpOptions createOptions = new BmpOptions();
            createOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(createOptions, width, height))
            {
                // Clear background to white
                RasterImage raster = (RasterImage)image;
                int[] whitePixels = Enumerable.Repeat(Color.White.ToArgb(), width * height).ToArray();
                raster.SaveArgb32Pixels(new Rectangle(0, 0, width, height), whitePixels);

                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Black, 3);

                for (int i = 0; i < starPoints.Length; i++)
                {
                    Point start = starPoints[i];
                    Point end = starPoints[(i + 1) % starPoints.Length];
                    graphics.DrawLine(pen, start.X, start.Y, end.X, end.Y);
                }

                // Save the image (output path already bound)
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
 * 1. When you need to programmatically generate a custom star logo or badge and save it as a BMP file using Aspose.Imaging in C#.
 * 2. When creating printable game boards, puzzles, or educational worksheets that require a precisely positioned star shape drawn with line segments on a bitmap.
 * 3. When automating the production of Windows desktop icons or splash screens that must be stored in BMP format and include a stylized star graphic.
 * 4. When generating test images containing geometric shapes to validate image‑processing or computer‑vision algorithms in a .NET application.
 * 5. When adding a decorative star watermark to bitmap charts, diagrams, or reports as part of an automated reporting pipeline.
 */
