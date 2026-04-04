using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

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

        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterOptions = new SvgRasterizationOptions
            {
                BackgroundColor = Color.White,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            using (var ms = new MemoryStream())
            {
                vectorImage.Save(ms, pngOptions);
                ms.Position = 0;

                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 100,
                        ResolutionSettings = new ResolutionSetting(300, 300),
                        Source = new FileCreateSource(outputPath, false)
                    };

                    raster.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}