using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emz";
        string outputPath = "output.png";

        using (Image vectorImage = Image.Load(inputPath))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };

            using (var memoryStream = new MemoryStream())
            {
                vectorImage.Save(memoryStream, new PngOptions { VectorRasterizationOptions = vectorOptions });
                memoryStream.Position = 0;

                using (Image rasterImage = Image.Load(memoryStream))
                {
                    RasterImage raster = (RasterImage)rasterImage;
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}