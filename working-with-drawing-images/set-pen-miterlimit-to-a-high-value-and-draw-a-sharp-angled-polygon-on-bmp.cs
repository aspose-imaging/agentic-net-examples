// HOW-TO: Create Sharp‑Angled Polygon on BMP with High Miter Limit in C# (Aspose.Imaging for .NET)
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Black, 5);
                pen.MiterLimit = 20; // high value for sharp angles

                Point[] points = new Point[]
                {
                    new Point(250, 50),
                    new Point(260, 200),
                    new Point(400, 210),
                    new Point(270, 300),
                    new Point(300, 450),
                    new Point(250, 350),
                    new Point(200, 450),
                    new Point(230, 300),
                    new Point(100, 210),
                    new Point(240, 200)
                };

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
 * 1. When you need to generate a BMP illustration that includes a star‑shaped or other sharp‑cornered polygon without beveled joints.
 * 2. When you want to ensure crisp, pointed edges in vector drawings for technical diagrams by increasing the pen’s miter limit.
 * 3. When you are building a server‑side image generation service that outputs BMP files for legacy Windows applications.
 * 4. When you need to programmatically create custom icons or UI assets with precise geometric shapes in a .NET application.
 * 5. When you are testing or demonstrating Aspose.Imaging’s graphics API, especially the effect of the MiterLimit property on polygon rendering.
 */
