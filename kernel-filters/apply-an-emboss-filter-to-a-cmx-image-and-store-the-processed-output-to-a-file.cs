using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = "input.cmx";
        string tempRasterPath = "output\\temp.png";
        string outputPath = "output\\processed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure directories exist for temporary and final output
        Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load CMX vector image and rasterize it to PNG
        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions { PageSize = cmx.Size }
            };
            cmx.Save(tempRasterPath, pngOptions);
        }

        // Load the rasterized PNG, apply emboss filter, and save the result
        using (Image img = Image.Load(tempRasterPath))
        {
            RasterImage raster = (RasterImage)img;
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
            raster.Save(outputPath, new PngOptions());
        }

        // Clean up temporary raster file
        if (File.Exists(tempRasterPath))
        {
            File.Delete(tempRasterPath);
        }
    }
}