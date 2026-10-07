// HOW-TO: Draw a Blue Polygon on BMP Using Pen in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\polygon.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            int width = 400;
            int height = 300;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Point[] points = new Point[]
                {
                    new Point(50, 50),
                    new Point(350, 50),
                    new Point(300, 250),
                    new Point(100, 250)
                };

                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 5);

                graphics.DrawPolygon(pen, points);

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
 * 1. When you need to programmatically generate a BMP diagram with a highlighted polygon for a technical report.
 * 2. When creating a custom map overlay where city boundaries are drawn as blue polygons on a bitmap background.
 * 3. When building a Windows service that produces thumbnail images with geometric shapes for visual verification.
 * 4. When automating the creation of printable assets that require precise polygon outlines in a specific line thickness.
 * 5. When testing graphics rendering pipelines by drawing simple shapes on BMP files to compare output quality.
 */
