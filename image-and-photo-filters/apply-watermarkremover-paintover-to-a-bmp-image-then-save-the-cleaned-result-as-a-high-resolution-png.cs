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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.png";

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
                var bmpImage = (BmpImage)image;

                // Define a mask using a graphics path (ellipse covering most of the image)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, bmpImage.Width - 100, bmpImage.Height - 100)));
                mask.AddFigure(figure);

                // Create Telea algorithm options with the mask
                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                // Remove the watermark
                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(bmpImage, options);

                // Save the cleaned result as a high‑resolution PNG
                var pngOptions = new PngOptions();
                result.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}