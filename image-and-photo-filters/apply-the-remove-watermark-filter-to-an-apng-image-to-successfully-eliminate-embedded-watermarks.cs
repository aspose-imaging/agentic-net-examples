using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the APNG image
        using (var image = Image.Load(inputPath))
        {
            // Cast to APNG image and then to RasterImage for watermark removal
            var apngImage = (ApngImage)image;
            var raster = (RasterImage)apngImage;

            // Define the mask region (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 100)));
            mask.AddFigure(figure);

            // Create Telea watermark removal options with the mask
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Perform watermark removal
            using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
            {
                // Save the resulting image as APNG
                result.Save(outputPath, new ApngOptions());
            }
        }
    }
}