using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\output_winding.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 400, 400))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var path = new Aspose.Imaging.GraphicsPath(Aspose.Imaging.FillMode.Winding);
                var figure = new Aspose.Imaging.Figure();
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 300f, 300f)));
                path.AddFigure(figure);

                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2), path);
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}