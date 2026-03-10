using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input BigTIFF and output image
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Load the existing BigTIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to BigTiffImage
            BigTiffImage bigTiff = (BigTiffImage)image;

            // Create emboss filter options using a predefined convolution kernel
            var embossKernel = ConvolutionFilter.Emboss3x3;
            var filterOptions = new ConvolutionFilterOptions(embossKernel);

            // Apply the emboss filter to the entire image
            bigTiff.Filter(bigTiff.Bounds, filterOptions);

            // Save the filtered image as a standard TIFF
            bigTiff.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
        }
    }
}