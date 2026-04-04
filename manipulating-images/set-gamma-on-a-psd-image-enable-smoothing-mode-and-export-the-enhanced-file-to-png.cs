using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Adjust gamma on the raster data
            var raster = image as Aspose.Imaging.RasterImage;
            if (raster != null)
            {
                raster.AdjustGamma(2.2f);
            }

            // Configure PNG export with smoothing mode
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias
                }
            };

            // Save the enhanced image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}