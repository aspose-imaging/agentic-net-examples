using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        string inputPath = @"C:\Images\architectural.svg";
        string tempPngPath = @"C:\Images\temp_output.png";
        string outputPath = @"C:\Images\architectural_edges.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image svgImage = Image.Load(inputPath))
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Color.White
            };

            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            svgImage.Save(tempPngPath, pngOptions);
        }

        using (Image rasterImg = Image.Load(tempPngPath))
        {
            RasterImage rasterImage = (RasterImage)rasterImg;

            double[,] kernel = new double[,]
            {
                { -1, -2, -1 },
                { 0, 0, 0 },
                { 1, 2, 1 }
            };

            ConvolutionFilterOptions convOptions = new ConvolutionFilterOptions(kernel, 1.0, 3);

            rasterImage.Filter(rasterImage.Bounds, convOptions);

            PngOptions outOptions = new PngOptions();
            rasterImage.Save(outputPath, outOptions);
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}