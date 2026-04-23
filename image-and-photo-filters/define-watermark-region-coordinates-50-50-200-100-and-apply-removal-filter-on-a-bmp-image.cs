using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (null‑safe)
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
            Directory.CreateDirectory(outputDir);

        // Load the BMP image
        using (var image = Image.Load(inputPath))
        {
            var bmpImage = (BmpImage)image; // Cast to BMP image

            // Define watermark region (50,50,200,100) using a rectangle shape
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 100)));
            mask.AddFigure(figure);

            // Create Telea algorithm options with the mask
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Remove the watermark
            using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(bmpImage, options))
            {
                // Save the result as BMP using BmpOptions
                result.Save(outputPath, new BmpOptions());
            }
        }
    }
}