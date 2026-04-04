using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.tif";

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
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height,
                BackgroundColor = Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions,
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            using (MemoryStream pngStream = new MemoryStream())
            {
                vectorImage.Save(pngStream, pngOptions);
                pngStream.Position = 0;

                using (RasterImage rasterImage = (RasterImage)Image.Load(pngStream))
                {
                    using (BmpOptions bmpOpts = new BmpOptions())
                    {
                        using (Image canvas = Image.Create(bmpOpts, rasterImage.Width, rasterImage.Height))
                        {
                            Graphics graphics = new Graphics(canvas);
                            var shearMatrix = new Matrix(1f, 0.5f, 0f, 1f, 0f, 0f);
                            graphics.Transform = shearMatrix;
                            graphics.DrawImage(rasterImage, new Rectangle(0, 0, rasterImage.Width, rasterImage.Height));

                            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                            {
                                ResolutionSettings = new ResolutionSetting(300, 300)
                            };

                            canvas.Save(outputPath, tiffOptions);
                        }
                    }
                }
            }
        }
    }
}