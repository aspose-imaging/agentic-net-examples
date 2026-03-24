using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary raster file path
        string tempPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

        // Load EPS image and rasterize to temporary PNG
        using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
        {
            var rasterOptions = new Aspose.Imaging.ImageOptions.EpsRasterizationOptions
            {
                PageWidth = epsImage.Width,
                PageHeight = epsImage.Height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            epsImage.Save(tempPath, pngOptions);
        }

        // Load the rasterized image, apply emboss filter, and save final output
        using (var image = Image.Load(tempPath))
        {
            var raster = (RasterImage)image;

            var embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);

            raster.Filter(raster.Bounds, filterOptions);
            raster.Save(outputPath, new PngOptions());
        }
    }
}