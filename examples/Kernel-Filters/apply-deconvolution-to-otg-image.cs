using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths (adjust as needed)
        string inputPath = "input.otg";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load OTG image and rasterize to PNG
        using (Image otgImage = Image.Load(inputPath))
        {
            // Prepare PNG options with vector rasterization settings
            PngOptions pngOptions = new PngOptions();
            OtgRasterizationOptions rasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };
            pngOptions.VectorRasterizationOptions = rasterizationOptions;

            // Save rasterized PNG to temporary file
            otgImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG as RasterImage
        using (Image img = Image.Load(tempPngPath))
        {
            RasterImage rasterImage = (RasterImage)img;

            // Apply a deconvolution filter (Gauss-Wiener) to the entire image
            rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));

            // Save the filtered image
            rasterImage.Save(outputPath, new PngOptions());
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}