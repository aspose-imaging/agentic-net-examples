using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input CMX, temporary raster image, and final output
        string inputCmxPath = "input.cmx";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load the CMX image and rasterize it to a temporary PNG file
        using (Image cmxImage = Image.Load(inputCmxPath))
        {
            // Save as PNG to obtain a raster representation
            PngOptions pngOptions = new PngOptions();
            cmxImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply Sharpen filter, and save the result
        using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
        {
            // Apply Sharpen filter with kernel size 5 and sigma 4.0
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image
            PngOptions outputOptions = new PngOptions();
            raster.Save(outputPath, outputOptions);
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}