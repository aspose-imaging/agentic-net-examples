using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output PSD file paths
        string inputPath = args.Length > 0 ? args[0] : "input.psd";
        string outputPath = args.Length > 1 ? args[1] : "output.psd";

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply a motion Wiener filter (motion blur) to the entire image
            // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the filtered image back as PSD
            PsdOptions saveOptions = new PsdOptions();
            raster.Save(outputPath, saveOptions);
        }
    }
}