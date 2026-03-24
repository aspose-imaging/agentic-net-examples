using System;
using System.IO;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\result.png";

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
            // Cast to specific PNG image type
            var pngImage = (PngImage)image;

            // Apply a Gaussian blur filter to the raster data
            var raster = (Aspose.Imaging.RasterImage)pngImage;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Define the watermark mask (ellipse shape)
            var mask = new Aspose.Imaging.GraphicsPath();
            var figure = new Aspose.Imaging.Figure();
            figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Create watermark removal options (Telea algorithm)
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Perform watermark removal
            var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options);

            // Save the resulting image
            result.Save(outputPath);
        }
    }
}