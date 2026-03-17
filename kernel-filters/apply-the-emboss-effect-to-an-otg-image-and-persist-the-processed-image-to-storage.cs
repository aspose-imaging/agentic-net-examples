using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input OTG, temporary PNG, and final output
        string inputPath = "input.otg";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load the OTG image and rasterize it to a PNG file
        using (Image otgImage = Image.Load(inputPath))
        {
            // Set up rasterization options for OTG
            OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };

            // Configure PNG save options with the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image to a temporary PNG file
            otgImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG as a RasterImage
        using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
        {
            // Apply the Emboss effect using a predefined convolution kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image to the desired output path
            raster.Save(outputPath);
        }
    }
}