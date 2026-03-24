using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.wmf";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        // Load WMF and rasterize to a temporary PNG
        var wmfImage = (Aspose.Imaging.FileFormats.Wmf.WmfImage)Aspose.Imaging.Image.Load(inputPath);
        using (wmfImage)
        {
            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            wmfImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG as a RasterImage
        var raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(tempPngPath);
        using (raster)
        {
            // Apply Emboss filter using ConvolutionFilter.Emboss3x3
            var embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
            raster.Filter(raster.Bounds, filterOptions);

            // Save the processed image
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            raster.Save(outputPath, new PngOptions());
        }
    }
}