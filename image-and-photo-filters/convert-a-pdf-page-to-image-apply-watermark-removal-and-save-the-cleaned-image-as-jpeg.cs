using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.pdf";
        string outputPath = "Output\\cleaned.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Cast to RasterImage for watermark removal
                RasterImage raster = (RasterImage)pdfImage;
                raster.CacheData();

                // Define mask (example ellipse)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
                mask.AddFigure(figure);

                // Create watermark removal options
                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                // Remove watermark
                using (RasterImage cleaned = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                {
                    var jpegOptions = new JpegOptions();
                    cleaned.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}