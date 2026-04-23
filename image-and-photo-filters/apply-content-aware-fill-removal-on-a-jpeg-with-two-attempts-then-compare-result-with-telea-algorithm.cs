using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputDir = "Output";
            string outputPathCaf = Path.Combine(outputDir, "output_caf.jpg");
            string outputPathTelea = Path.Combine(outputDir, "output_telea.jpg");

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathCaf));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathTelea));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                var jpegImage = (JpegImage)image;

                // Define the mask region (example ellipse)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 150)));
                mask.AddFigure(figure);

                // Content‑Aware Fill removal with two attempts
                var cafOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 2
                };
                using (RasterImage cafResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(jpegImage, cafOptions))
                {
                    cafResult.Save(outputPathCaf);
                }

                // Telea algorithm removal for comparison
                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (RasterImage teleaResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(jpegImage, teleaOptions))
                {
                    teleaResult.Save(outputPathTelea);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}