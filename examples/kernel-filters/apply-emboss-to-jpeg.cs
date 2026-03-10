using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output_emboss.jpg";

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply an emboss filter using a predefined convolution kernel
            rasterImage.Filter(
                rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

            // Set JPEG save options (default options can be used)
            JpegOptions jpegOptions = new JpegOptions();

            // Save the processed image
            rasterImage.Save(outputPath, jpegOptions);
        }
    }
}