using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\landscape.png";
        string outputPath = @"C:\Images\landscape_vertical_edges.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            double[,] kernel = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel);

            raster.Filter(raster.Bounds, filterOptions);

            PngOptions saveOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            raster.Save(outputPath, saveOptions);
        }
    }
}