using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output paths
        string inputPath = Path.Combine("Input", "sample.pdf");
        string outputPath = Path.Combine("Output", "cleaned.jpg");
        string tempPath = Path.Combine("Output", "temp.jpg");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

        // Load PDF and rasterize first page to a temporary JPEG
        using (Image pdfImage = Image.Load(inputPath))
        {
            JpegOptions jpegOptions = new JpegOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = pdfImage.Width,
                    PageHeight = pdfImage.Height
                }
            };

            pdfImage.Save(tempPath, jpegOptions);
        }

        // Load the rasterized image, apply watermark removal, and save the cleaned JPEG
        using (Image tempImg = Image.Load(tempPath))
        {
            RasterImage raster = (RasterImage)tempImg;

            // Define a mask covering the whole image (adjust as needed)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(0, 0, raster.Width, raster.Height)));
            mask.AddFigure(figure);

            var watermarkOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, watermarkOptions))
            {
                result.Save(outputPath);
            }
        }
    }
}