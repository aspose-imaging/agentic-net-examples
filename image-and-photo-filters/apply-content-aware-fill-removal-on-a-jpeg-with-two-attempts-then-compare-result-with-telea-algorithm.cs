using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPathCaf = "output_caf.jpg";
        string outputPathTelea = "output_telea.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDirCaf = Path.GetDirectoryName(outputPathCaf);
        if (!string.IsNullOrEmpty(outputDirCaf))
            Directory.CreateDirectory(outputDirCaf);

        string outputDirTelea = Path.GetDirectoryName(outputPathTelea);
        if (!string.IsNullOrEmpty(outputDirTelea))
            Directory.CreateDirectory(outputDirTelea);

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var jpegImage = (JpegImage)image;

                // Define mask region
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
                mask.AddFigure(figure);

                // Content‑aware fill removal with two attempts
                var cafOptions = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 2
                };
                using (var resultCaf = WatermarkRemover.PaintOver(jpegImage, cafOptions))
                {
                    resultCaf.Save(outputPathCaf);
                }

                // Telea algorithm removal
                var teleaOptions = new TeleaWatermarkOptions(mask);
                using (var resultTelea = WatermarkRemover.PaintOver(jpegImage, teleaOptions))
                {
                    resultTelea.Save(outputPathTelea);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}