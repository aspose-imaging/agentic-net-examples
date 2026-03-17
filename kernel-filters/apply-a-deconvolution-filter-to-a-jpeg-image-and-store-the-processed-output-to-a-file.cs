using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input JPEG and output processed image
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gauss‑Wiener deconvolution filter (radius = 5, sigma = 4.0)
            rasterImage.Filter(rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));

            // Configure JPEG save options (default settings)
            JpegOptions jpegOptions = new JpegOptions();

            // Save the processed image to the specified output path
            rasterImage.Save(outputPath, jpegOptions);
        }
    }
}