using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for watermark removal
            RasterImage raster = (RasterImage)image;

            // Create mask (example: ellipse covering a region)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 150)));
            mask.AddFigure(figure);

            // Configure watermark removal options (using Telea algorithm)
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Apply watermark removal
            using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
            {
                // Set high-resolution PNG options (e.g., 300 DPI)
                var pngOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                // Save the cleaned image as PNG
                result.Save(outputPath, pngOptions);
            }
        }
    }
}