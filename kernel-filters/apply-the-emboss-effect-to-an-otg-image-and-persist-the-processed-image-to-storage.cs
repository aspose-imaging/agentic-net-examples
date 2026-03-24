using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = "input\\sample.otg";
        string tempPath = "temp\\temp.png";
        string outputPath = "output\\embossed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure directories for temporary and output files exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load OTG image and rasterize to a temporary PNG
        using (Image otgImage = Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                }
            };
            otgImage.Save(tempPath, pngOptions);
        }

        // Load the rasterized PNG, apply emboss filter, and save the result
        using (RasterImage raster = (RasterImage)Image.Load(tempPath))
        {
            // Apply emboss effect using a predefined convolution kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
            raster.Save(outputPath, new PngOptions());
        }
    }
}