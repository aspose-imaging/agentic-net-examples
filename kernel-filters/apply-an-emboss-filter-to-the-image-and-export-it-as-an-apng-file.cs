using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input image and output APNG
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Load the source image as a raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Apply emboss filter using the predefined 3x3 emboss kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Prepare APNG options (single-frame animation)
            ApngOptions apngOptions = new ApngOptions
            {
                // Set default frame duration (milliseconds)
                DefaultFrameTime = 100,
                // Ensure the PNG color type supports alpha channel
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Save the filtered raster image as an APNG file
            raster.Save(outputPath, apngOptions);
        }
    }
}