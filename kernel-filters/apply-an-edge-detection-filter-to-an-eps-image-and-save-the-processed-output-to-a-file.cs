using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";
        string tempPngPath = "temp.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load EPS and rasterize to a temporary PNG
        using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
        {
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = epsImage.Width,
                PageHeight = epsImage.Height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            epsImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG as a RasterImage
        using (var image = Image.Load(tempPngPath))
        {
            var raster = (RasterImage)image;

            // Edge detection kernel (3x3)
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            var filterOptions = new ConvolutionFilterOptions(kernel);
            raster.Filter(raster.Bounds, filterOptions);
            raster.Save(outputPath);
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}