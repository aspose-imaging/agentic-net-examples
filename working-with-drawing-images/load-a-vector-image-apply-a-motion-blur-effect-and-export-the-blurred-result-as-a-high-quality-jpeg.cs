using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

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

        using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
        {
            var rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            using (var rasterStream = new MemoryStream())
            {
                vectorImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                using (Aspose.Imaging.Image rasterImage = Aspose.Imaging.Image.Load(rasterStream))
                {
                    var raster = (Aspose.Imaging.RasterImage)rasterImage;

                    var jpegOptions = new JpegOptions
                    {
                        Quality = 95
                    };

                    raster.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}