using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            int newWidth = raster.Width * 2;
            int newHeight = raster.Height * 2;
            raster.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            using (SvgOptions svgOptions = new SvgOptions())
            {
                raster.Save(outputPath, svgOptions);
            }
        }
    }
}