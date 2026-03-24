using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (var image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to specific format (PNG) to satisfy WatermarkRemover requirements
            var pngImage = (Aspose.Imaging.FileFormats.Png.PngImage)image;

            // Define the watermark mask (example ellipse)
            var mask = new Aspose.Imaging.GraphicsPath();
            var firstFigure = new Aspose.Imaging.Figure();
            firstFigure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(firstFigure);

            // Create Telea algorithm options with the mask
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Remove the watermark
            var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options);

            // Save the processed image
            result.Save(outputPath);
        }
    }
}