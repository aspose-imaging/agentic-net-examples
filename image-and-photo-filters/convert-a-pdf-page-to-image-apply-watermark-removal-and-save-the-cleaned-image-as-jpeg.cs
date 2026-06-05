using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pdf";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            using (Image pdfImage = Image.Load(inputPath))
            {
                using (var ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    pdfImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImg;

                        var mask = new GraphicsPath();
                        var figure = new Figure();
                        figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                        mask.AddFigure(figure);

                        var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                        RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options);

                        var jpegOptions = new JpegOptions();
                        result.Save(outputPath, jpegOptions);
                        result.Dispose();
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