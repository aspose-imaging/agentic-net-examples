using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.svg";
        string tempPath = "temp/temp.png";
        string outputPath = "output/output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image vectorImage = Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = vectorImage.Width,
                    PageHeight = vectorImage.Height,
                    BackgroundColor = Color.White
                }
            };
            vectorImage.Save(tempPath, pngOptions);
        }

        using (Image rasterImage = Image.Load(tempPath))
        {
            var raster = (RasterImage)rasterImage;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

            var jpegOptions = new JpegOptions
            {
                Quality = 95
            };
            raster.Save(outputPath, jpegOptions);
        }
    }
}