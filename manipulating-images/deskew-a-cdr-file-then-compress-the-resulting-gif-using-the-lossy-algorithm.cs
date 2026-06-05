using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = vectorOptions
                    };

                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.NormalizeAngle(false, Aspose.Imaging.Color.White);

                        var gifOptions = new GifOptions
                        {
                            MaxDiff = 80
                        };

                        raster.Save(outputPath, gifOptions);
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