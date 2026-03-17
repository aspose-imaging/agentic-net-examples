using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input AVIF image path
        string inputPath = "input.avif";
        // Output JPEG image path (fallback since AVIF save options are not available)
        string outputPath = "output.jpg";

        // Load the AVIF image (as a generic Image) and cast to RasterImage for processing
        using (Image image = Image.Load(inputPath))
        {
            // Ensure the image is a raster image
            using (RasterImage rasterImage = (RasterImage)image)
            {
                // Apply a motion Wiener filter (used here as a motion‑blur effect)
                // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

                // Save the processed image as JPEG
                JpegOptions jpegOptions = new JpegOptions();
                rasterImage.Save(outputPath, jpegOptions);
            }
        }
    }
}