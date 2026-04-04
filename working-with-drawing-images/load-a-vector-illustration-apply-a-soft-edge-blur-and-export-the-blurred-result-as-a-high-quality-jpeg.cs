using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        string inputPath = "input.svg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            // Prepare JPEG save options with high quality
            var jpegOptions = new JpegOptions { Quality = 100 };

            if (image is VectorImage)
            {
                // Rasterize vector image via in‑memory PNG
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, new PngOptions());
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        var raster = (RasterImage)rasterImg;
                        raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 2.0));
                        raster.Save(outputPath, jpegOptions);
                    }
                }
            }
            else
            {
                var raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 2.0));
                raster.Save(outputPath, jpegOptions);
            }
        }
    }
}