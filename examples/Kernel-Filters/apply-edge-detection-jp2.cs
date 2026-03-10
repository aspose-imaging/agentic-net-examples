using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input JPEG2000 image and output result
        string inputPath = "input.jp2";
        string outputPath = "output.jp2";

        // Load the JPEG2000 image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage raster = (RasterImage)image;

            // Apply a sharpen filter (used here as edge detection)
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Set up JPEG2000 save options
            Jpeg2000Options saveOptions = new Jpeg2000Options
            {
                Irreversible = true,
                Codec = Jpeg2000Codec.J2K
            };

            // Save the filtered image
            raster.Save(outputPath, saveOptions);
        }
    }
}