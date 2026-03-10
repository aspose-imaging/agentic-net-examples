using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths
        string inputPath = "input.otg";
        string tempRasterPath = "temp.png";
        string outputPath = "output.png";

        // Rasterize OTG to PNG (temporary file)
        using (Image otgImage = Image.Load(inputPath))
        {
            // Prepare PNG options with vector rasterization for OTG
            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };
            // Save rasterized image to temporary path
            otgImage.Save(tempRasterPath, pngOptions);
        }

        // Load the rasterized image, apply Emboss filter, and save result
        using (RasterImage raster = (RasterImage)Image.Load(tempRasterPath))
        {
            // Apply Emboss filter using predefined kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the filtered image
            PngOptions outputOptions = new PngOptions();
            raster.Save(outputPath, outputOptions);
        }
    }
}