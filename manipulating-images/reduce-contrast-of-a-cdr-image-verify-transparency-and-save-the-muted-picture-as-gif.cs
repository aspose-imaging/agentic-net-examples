using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var rasterOptions = new GifOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height,
                            BackgroundColor = Aspose.Imaging.Color.White
                        }
                    };

                    cdr.Save(ms, rasterOptions);
                    ms.Position = 0;

                    using (GifImage gif = (GifImage)Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)gif;
                        raster.AdjustContrast(-30f);

                        bool hasTransparency = gif.HasTransparentColor;
                        Console.WriteLine($"Has transparency: {hasTransparency}");

                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        gif.Save(outputPath, new GifOptions());
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