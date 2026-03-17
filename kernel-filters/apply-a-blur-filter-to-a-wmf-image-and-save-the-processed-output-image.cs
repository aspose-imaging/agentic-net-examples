using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input WMF file path
        string inputWmfPath = "input.wmf";
        // Temporary rasterized PNG path
        string tempPngPath = "temp.png";
        // Final output image path (blurred PNG)
        string outputPath = "output.png";

        // Load the WMF image and rasterize it to a PNG file
        using (Image wmfImage = Image.Load(inputWmfPath))
        {
            // Configure rasterization options for WMF
            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // Set PNG options with the vector rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image to a temporary PNG file
            wmfImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply Gaussian blur, and save the result
        using (Image rasterImage = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)rasterImage;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the entire image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the blurred image as PNG
            raster.Save(outputPath, new PngOptions());
        }

        // Optionally delete the temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}