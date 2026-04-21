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
            // Hardcoded input path
            string inputPath = "input\\sample.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create a simple elliptical mask (used for all attempts)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
            mask.AddFigure(figure);

            // Different MaxPaintingAttempts values to observe visual smoothness
            int[] attempts = new int[] { 1, 4, 8 };
            foreach (int attempt in attempts)
            {
                // Output path includes the attempt count for distinction
                string outputPath = $"output\\result_{attempt}.png";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var image = Image.Load(inputPath))
                {
                    var pngImage = (PngImage)image;

                    // Configure ContentAwareFillWatermarkOptions with the current attempt count
                    var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                    {
                        MaxPaintingAttempts = attempt
                    };

                    // Apply the watermark removal (content-aware fill)
                    using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options))
                    {
                        // Save the result; higher attempts generally produce smoother, more natural fills
                        result.Save(outputPath);
                    }
                }

                // Comment: Increasing MaxPaintingAttempts allows the algorithm to try more painting variants,
                // selecting the best one, which typically yields a smoother and more seamless filled region.
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}