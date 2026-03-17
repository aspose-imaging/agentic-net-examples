using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Temp\input.emf";
        string tempPngPath = Path.Combine(Path.GetDirectoryName(inputPath), "temp.png");
        string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "output_edge.png");

        using (Image image = Image.Load(inputPath))
        {
            EmfImage emfImage = (EmfImage)image;
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = emfImage.Width,
                PageHeight = emfImage.Height
            };
            emfImage.Save(tempPngPath, new PngOptions { VectorRasterizationOptions = rasterOptions });
        }

        using (Image rasterImageContainer = Image.Load(tempPngPath))
        {
            RasterImage rasterImage = (RasterImage)rasterImageContainer;

            double[,] kernel = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

            rasterImage.Save(outputPath, new PngOptions());
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}