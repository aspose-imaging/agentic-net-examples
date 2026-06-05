using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                var bmpImage = (BmpImage)image;

                // Define a simple rectangular mask for the watermark area
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 200)));
                mask.AddFigure(figure);

                // Use Telea algorithm for watermark removal
                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                // Remove the watermark
                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(bmpImage, options);

                // Save the cleaned image as high‑resolution PNG
                var pngOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };
                result.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}