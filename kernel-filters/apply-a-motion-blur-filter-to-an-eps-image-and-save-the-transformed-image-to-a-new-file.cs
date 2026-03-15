using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input EPS, temporary raster PNG, and final output image
        string inputEpsPath = "input.eps";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load the EPS image and rasterize it to a PNG file
        using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputEpsPath))
        {
            // Set rasterization options to match the EPS dimensions
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = epsImage.Width,
                PageHeight = epsImage.Height
            };

            // Configure PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image to a temporary PNG file
            epsImage.Save(tempPngPath, pngOptions);
        }

        // Load the temporary PNG as a raster image, apply Motion Wiener filter, and save the result
        using (Image img = Image.Load(tempPngPath))
        {
            var rasterImage = (RasterImage)img;

            // Apply Motion Wiener filter (length=10, smooth=1.0, angle=90.0)
            rasterImage.Filter(
                rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the filtered image to the final output file
            rasterImage.Save(outputPath, new PngOptions());
        }

        // Optionally delete the temporary PNG file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}