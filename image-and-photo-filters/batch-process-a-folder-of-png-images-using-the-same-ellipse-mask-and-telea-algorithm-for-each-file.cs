using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            // Ensure input directory exists
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] files = Directory.GetFiles(inputDir, "*.png");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + "_processed.png");

                // Ensure output directory exists (null‑safe)
                string outputDirPath = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDirPath))
                {
                    Directory.CreateDirectory(outputDirPath);
                }

                using (var image = Image.Load(inputPath))
                {
                    var pngImage = (PngImage)image;

                    // Create a common ellipse mask
                    var mask = new GraphicsPath();
                    var figure = new Figure();
                    // Example ellipse covering the central area of the image
                    figure.AddShape(new EllipseShape(new RectangleF(50, 50, pngImage.Width - 100, pngImage.Height - 100)));
                    mask.AddFigure(figure);

                    var options = new TeleaWatermarkOptions(mask);

                    using (var result = WatermarkRemover.PaintOver(pngImage, options))
                    {
                        var saveOptions = new PngOptions { Source = new FileCreateSource(outputPath, false) };
                        result.Save(outputPath, saveOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}