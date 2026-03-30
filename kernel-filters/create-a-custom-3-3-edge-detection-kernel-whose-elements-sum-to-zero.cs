using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_edge.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1, 8, -1 },
                { -1, -1, -1 }
            };

            var options = new ConvolutionFilterOptions(kernel, factor: 1.0, bias: 0);
            rasterImage.Filter(rasterImage.Bounds, options);

            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}