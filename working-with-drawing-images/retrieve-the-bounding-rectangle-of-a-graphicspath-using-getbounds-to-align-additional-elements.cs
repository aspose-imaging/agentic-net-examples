using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                RectangleF rect = new RectangleF(100f, 80f, 200f, 150f);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(rect));
                path.AddFigure(figure);

                Console.WriteLine($"Bounds: X={rect.X}, Y={rect.Y}, Width={rect.Width}, Height={rect.Height}");

                graphics.DrawPath(new Pen(Color.Black, 2), path);
                graphics.DrawRectangle(new Pen(Color.Red, 2), rect);

                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}