using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input PSD file path
        string inputPath = "input.psd";
        // Output PSD file path
        string outputPath = "output_deconvolved.psd";

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply a motion deconvolution filter (MotionWienerFilterOptions)
            // Parameters: length = 10, sigma = 1.0, angle = 0 degrees
            rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 0.0));

            // Prepare PSD save options
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.CompressionMethod = CompressionMethod.RLE;

            // Save the filtered image as PSD
            image.Save(outputPath, psdOptions);
        }
    }
}