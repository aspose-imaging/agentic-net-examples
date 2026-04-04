using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/optimized.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            using (var tempOptions = new PngOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                }
            })
            {
                using (var ms = new MemoryStream())
                {
                    epsImage.Save(ms, tempOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        var palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256, PaletteMiningMethod.Histogram);

                        using (var finalOptions = new PngOptions
                        {
                            ColorType = PngColorType.IndexedColor,
                            Palette = palette,
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = epsImage.Width,
                                PageHeight = epsImage.Height
                            }
                        })
                        {
                            epsImage.Save(outputPath, finalOptions);
                        }
                    }
                }
            }
        }
    }
}