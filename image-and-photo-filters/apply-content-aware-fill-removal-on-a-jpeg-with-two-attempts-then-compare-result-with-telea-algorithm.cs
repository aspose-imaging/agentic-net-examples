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
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPathCaf = "output/caf_result.jpg";
            string outputPathTelea = "output/telea_result.jpg";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathCaf));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathTelea));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                JpegImage jpegImage = (JpegImage)image;

                // Define a mask (example ellipse)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 150)));
                mask.AddFigure(figure);

                // Content‑aware fill removal with two attempts
                var cafOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 2
                };
                var cafResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(jpegImage, cafOptions);
                cafResult.Save(outputPathCaf);
                cafResult.Dispose();

                // Telea algorithm removal
                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                var teleaResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(jpegImage, teleaOptions);
                teleaResult.Save(outputPathTelea);
                teleaResult.Dispose();
            }

            // Simple pixel‑wise comparison of the two results
            using (RasterImage imgCaf = (RasterImage)Image.Load(outputPathCaf))
            using (RasterImage imgTelea = (RasterImage)Image.Load(outputPathTelea))
            {
                int width = Math.Min(imgCaf.Width, imgTelea.Width);
                int height = Math.Min(imgCaf.Height, imgTelea.Height);
                int diffCount = 0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int pixelCaf = imgCaf.GetArgb32Pixel(x, y);
                        int pixelTelea = imgTelea.GetArgb32Pixel(x, y);
                        if (pixelCaf != pixelTelea)
                            diffCount++;
                    }
                }

                Console.WriteLine($"Differing pixels: {diffCount}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}