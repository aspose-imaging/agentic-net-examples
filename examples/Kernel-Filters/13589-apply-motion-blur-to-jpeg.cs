using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply a motion Wiener filter (motion blur) to the entire image
            // Parameters: length, smooth value, angle in degrees
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image as JPEG with desired quality
            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.Quality = 90; // Set JPEG quality (0-100)
                raster.Save(outputPath, jpegOptions);
            }
        }
    }
}