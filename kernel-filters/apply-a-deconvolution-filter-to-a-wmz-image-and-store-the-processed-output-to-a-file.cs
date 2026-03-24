using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\sample.wmz";
        string outputPath = @"C:\Images\sample_processed.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
        {
            var rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };

            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                using (Aspose.Imaging.Image rasterImage = Aspose.Imaging.Image.Load(memoryStream))
                {
                    var raster = (Aspose.Imaging.RasterImage)rasterImage;
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}