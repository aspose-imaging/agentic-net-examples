using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath2 = "output_attempts_2.png";
            string outputPath5 = "output_attempts_5.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath5));

            // Load the source image
            using (var image = Image.Load(inputPath))
            {
                // Cast to specific format (PNG) for watermark removal
                var pngImage = (PngImage)image;

                // Define a simple elliptical mask
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                mask.AddFigure(figure);

                // ----------- Attempt with MaxPaintingAttempts = 2 -----------
                var options2 = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 2 // Fewer attempts may produce less smooth fill
                };

                using (var result2 = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options2))
                {
                    // Save the result
                    result2.Save(outputPath2, new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    });
                }

                // ----------- Attempt with MaxPaintingAttempts = 5 -----------
                var options5 = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 5 // More attempts allow the algorithm to choose a better variant, resulting in smoother visual fill
                };

                using (var result5 = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options5))
                {
                    // Save the result
                    result5.Save(outputPath5, new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}