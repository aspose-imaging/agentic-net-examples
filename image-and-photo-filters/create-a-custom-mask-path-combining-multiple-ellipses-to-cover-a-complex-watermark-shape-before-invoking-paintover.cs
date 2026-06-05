using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
            Directory.CreateDirectory(outputDir);

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();

                var fig1 = new Figure();
                fig1.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 150)));
                mask.AddFigure(fig1);

                var fig2 = new Figure();
                fig2.AddShape(new EllipseShape(new RectangleF(300, 200, 180, 120)));
                mask.AddFigure(fig2);

                var fig3 = new Figure();
                fig3.AddShape(new EllipseShape(new RectangleF(500, 50, 150, 200)));
                mask.AddFigure(fig3);

                var options = new TeleaWatermarkOptions(mask);

                using (var result = WatermarkRemover.PaintOver(pngImage, options))
                {
                    result.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}