using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input PSD and output PSD
        string inputPath = @"c:\temp\input.psd";
        string outputPath = @"c:\temp\output_emboss.psd";

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage raster = (RasterImage)image;

            // Apply the emboss filter using a predefined convolution kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Set PSD save options (optional compression and color mode)
            PsdOptions psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE,
                ColorMode = ColorModes.Rgb
            };

            // Save the filtered image as PSD
            raster.Save(outputPath, psdOptions);
        }
    }
}