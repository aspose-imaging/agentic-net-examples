using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input AVIF image path
        string inputPath = "input.avif";
        // Output JPEG image path (fallback for unsupported AVIF save)
        string outputPath = "output.jpg";

        // Load the AVIF image (AvifImage is a raster image)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering methods
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Prepare JPEG save options with a file create source
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 90 };

            // Save the processed image as JPEG
            raster.Save(outputPath, jpegOptions);
        }
    }
}