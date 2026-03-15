using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = Path.Combine("C:", "Images", "input.jp2");
        string outputPath = Path.Combine("C:", "Images", "output.jp2");

        // Load the JPEG2000 image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply a motion deconvolution filter (length, sigma, angle)
            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image as JPEG2000
            raster.Save(outputPath, new Jpeg2000Options());
        }
    }
}