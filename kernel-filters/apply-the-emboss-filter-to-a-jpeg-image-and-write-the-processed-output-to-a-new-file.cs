using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (use arguments if provided)
        string inputPath = args.Length > 0 ? args[0] : "input.jpg";
        string outputPath = args.Length > 1 ? args[1] : "output_emboss.jpg";

        // Load the JPEG image as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Create an emboss filter using the predefined convolution kernel
            double[,] embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);

            // Apply the emboss filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the processed image as JPEG
            var jpegOptions = new JpegOptions
            {
                Quality = 90 // optional quality setting
            };
            raster.Save(outputPath, jpegOptions);
        }
    }
}