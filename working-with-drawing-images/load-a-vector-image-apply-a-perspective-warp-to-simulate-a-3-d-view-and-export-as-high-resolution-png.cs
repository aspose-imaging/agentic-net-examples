using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

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
                PageSize = vectorImage.Size,
                BackgroundColor = Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions,
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            using (MemoryStream memoryStream = new MemoryStream())
            {
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    using (Image outputImage = Image.Create(pngOptions, rasterImage.Width, rasterImage.Height))
                    {
                        Graphics graphics = new Graphics(outputImage);
                        graphics.DrawImage(rasterImage, new Point(0, 0));
                        outputImage.Save(outputPath);
                    }
                }
            }
        }
    }
}