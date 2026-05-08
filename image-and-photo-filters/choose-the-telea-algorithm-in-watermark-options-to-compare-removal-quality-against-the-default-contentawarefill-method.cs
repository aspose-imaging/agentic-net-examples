using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPathTelea = "output_telea.png";
            string outputPathContent = "output_content.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist (null-safe)
            string dirTelea = Path.GetDirectoryName(outputPathTelea);
            if (!string.IsNullOrEmpty(dirTelea)) Directory.CreateDirectory(dirTelea);

            string dirContent = Path.GetDirectoryName(outputPathContent);
            if (!string.IsNullOrEmpty(dirContent)) Directory.CreateDirectory(dirContent);

            // Load the image
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                // Define mask (ellipse)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                // Telea algorithm
                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (var teleaResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, teleaOptions))
                {
                    teleaResult.Save(outputPathTelea);
                }

                // Content Aware Fill algorithm (default)
                var contentOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };
                using (var contentResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, contentOptions))
                {
                    contentResult.Save(outputPathContent);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}