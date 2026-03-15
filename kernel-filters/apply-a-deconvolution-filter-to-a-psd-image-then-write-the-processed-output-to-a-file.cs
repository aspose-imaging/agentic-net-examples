using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.psd";
        string outputPath = "output.psd";

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage raster = (RasterImage)image;

            // Create a deconvolution filter (Motion Wiener) with desired parameters
            var deconvOptions = new MotionWienerFilterOptions(10, 1.0, 0.0);

            // Apply the filter to the entire image
            raster.Filter(raster.Bounds, deconvOptions);

            // Prepare PSD save options (optional compression setting)
            var psdOptions = new PsdOptions
            {
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE
            };

            // Save the processed image as PSD
            image.Save(outputPath, psdOptions);
        }
    }
}