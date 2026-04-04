using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
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

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (var image = Image.Load(inputPath))
        {
            // Cast to RasterImage for watermark removal
            var raster = (RasterImage)image;

            // Define watermark region (x=50, y=50, width=200, height=100)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 100)));
            mask.AddFigure(figure);

            // Create Telea algorithm options with the mask
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Apply watermark removal
            using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
            {
                // Save the resulting image as BMP
                result.Save(outputPath, new BmpOptions());
            }
        }
    }
}