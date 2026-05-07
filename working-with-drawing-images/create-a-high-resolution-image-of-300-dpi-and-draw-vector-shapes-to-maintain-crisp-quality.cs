using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\highres.png";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            int width = 2000;
            int height = 2000;

            using (Image image = Image.Create(pngOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen borderPen = new Pen(Color.Black, 5);
                graphics.DrawRectangle(borderPen, new Rectangle(10, 10, width - 20, height - 20));

                Pen ellipsePen = new Pen(Color.Red, 3);
                graphics.DrawEllipse(ellipsePen, new Rectangle(100, 100, width - 200, height - 200));

                Pen linePen = new Pen(Color.Blue, 2);
                graphics.DrawLine(linePen, new Point(10, 10), new Point(width - 10, height - 10));

                Pen polyPen = new Pen(Color.Green, 4);
                graphics.DrawPolygon(polyPen, new[]
                {
                    new Point(width / 2, 100),
                    new Point(100, height - 100),
                    new Point(width - 100, height - 100)
                });

                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}