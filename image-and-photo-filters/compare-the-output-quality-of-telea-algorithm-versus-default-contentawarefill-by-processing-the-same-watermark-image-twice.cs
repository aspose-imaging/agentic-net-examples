using System;
using System.IO;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "watermark.png";
            string outputTelea = "output_telea.png";
            string outputCaf = "output_caf.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputTelea));
            Directory.CreateDirectory(Path.GetDirectoryName(outputCaf));

            using (var image = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngImage = (Aspose.Imaging.FileFormats.Png.PngImage)image;

                var mask = new Aspose.Imaging.GraphicsPath();
                var figure = new Aspose.Imaging.Figure();
                figure.AddShape(new Aspose.Imaging.Shapes.EllipseShape(new Aspose.Imaging.RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (var teleaResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, teleaOptions))
                {
                    teleaResult.Save(outputTelea);
                }

                var cafOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };
                using (var cafResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, cafOptions))
                {
                    cafResult.Save(outputCaf);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}