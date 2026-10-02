// HOW-TO: Draw Smooth Bezier Curve on BMP with Rounded Caps in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/curves.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);
            int width = 200;
            int height = 200;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5);
                pen.StartCap = Aspose.Imaging.LineCap.Round;
                pen.EndCap = Aspose.Imaging.LineCap.Round;

                graphics.DrawBezier(
                    pen,
                    new Aspose.Imaging.PointF(10, 150),
                    new Aspose.Imaging.PointF(50, 10),
                    new Aspose.Imaging.PointF(150, 10),
                    new Aspose.Imaging.PointF(190, 150));

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
 * 1. When you need to generate a BMP signature or logo with anti‑aliased curved lines for a desktop application.
 * 2. When creating custom chart markers or decorative elements that require smooth Bezier curves with rounded ends in a reporting tool.
 * 3. When programmatically producing game assets such as curved paths or UI elements and saving them as BMP files for legacy compatibility.
 * 4. When exporting hand‑drawn style diagrams from a C# service where the pen’s rounded caps ensure visually pleasing line terminations.
 * 5. When automating the creation of printable templates that include smooth curves, and you must control line thickness and cap style using Aspose.Imaging.
 */
