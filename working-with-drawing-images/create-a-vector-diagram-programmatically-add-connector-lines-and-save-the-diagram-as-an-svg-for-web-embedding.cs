// HOW-TO: Create SVG Diagram with Lines and Filled Rectangle in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/diagram.svg";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(new SvgOptions(), 400, 300))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawLine(pen, new Aspose.Imaging.Point(50, 50), new Aspose.Imaging.Point(350, 50));
                graphics.DrawLine(pen, new Aspose.Imaging.Point(350, 50), new Aspose.Imaging.Point(350, 250));
                graphics.DrawLine(pen, new Aspose.Imaging.Point(350, 250), new Aspose.Imaging.Point(50, 250));
                graphics.DrawLine(pen, new Aspose.Imaging.Point(50, 250), new Aspose.Imaging.Point(50, 50));

                using (var brush = new SolidBrush(Aspose.Imaging.Color.LightBlue))
                {
                    graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(100, 100, 200, 100));
                }

                image.Save(outputPath);
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
 * 1. When you need to generate a scalable vector diagram on the fly for a web dashboard using C#.
 * 2. When you want to programmatically draw connector lines and shapes for flowcharts or network maps without using external design tools.
 * 3. When you must create an SVG file that can be embedded in HTML emails or web pages with precise dimensions and colors.
 * 4. When you require automated generation of printable schematics or UI mockups directly from server‑side code.
 * 5. When you need to produce lightweight vector graphics for responsive designs, ensuring they scale without loss of quality across devices.
 */
