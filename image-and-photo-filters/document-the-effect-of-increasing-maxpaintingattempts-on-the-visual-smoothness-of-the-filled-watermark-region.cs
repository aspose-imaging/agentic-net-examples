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
            string outputPathLow = "output_low.png";
            string outputPathHigh = "output_high.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist (null‑safe)
            string outDirLow = Path.GetDirectoryName(outputPathLow);
            if (!string.IsNullOrEmpty(outDirLow)) Directory.CreateDirectory(outDirLow);
            string outDirHigh = Path.GetDirectoryName(outputPathHigh);
            if (!string.IsNullOrEmpty(outDirHigh)) Directory.CreateDirectory(outDirHigh);

            // Load the source image
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                // Define a simple elliptical mask
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                // ------------------------------
                // Low MaxPaintingAttempts (2)
                // ------------------------------
                var optionsLow = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 2 // Fewer attempts may produce visible artifacts
                };
                using (var resultLow = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, optionsLow))
                {
                    resultLow.Save(outputPathLow);
                }

                // ------------------------------
                // High MaxPaintingAttempts (8)
                // ------------------------------
                var optionsHigh = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 8 // More attempts allow the algorithm to choose a smoother fill
                };
                using (var resultHigh = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, optionsHigh))
                {
                    resultHigh.Save(outputPathHigh);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}