using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        string inputPath = "input.cdr";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            GifOptions gifOptions = new GifOptions
            {
                MaxDiff = 80,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height,
                    BackgroundColor = Color.White
                }
            };

            using (RasterImage raster = (RasterImage)Image.Create(gifOptions, cdr.Width, cdr.Height))
            {
                raster.NormalizeAngle(false, Color.White);
                raster.Save(outputPath, gifOptions);
            }
        }
    }
}