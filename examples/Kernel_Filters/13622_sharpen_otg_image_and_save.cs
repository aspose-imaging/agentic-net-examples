using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input OTG file path
        string inputPath = "input.otg";

        // Temporary rasterized PNG path
        string tempPngPath = "temp.png";

        // Output path for the sharpened image
        string outputPath = "output.png";

        // Load the OTG image and rasterize it to PNG
        using (Image otgImage = Image.Load(inputPath))
        {
            // Configure rasterization options for OTG
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };

            // Set up PNG save options with the rasterization settings
            var pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Save the rasterized image to a temporary PNG file
            otgImage.Save(tempPngPath, pngSaveOptions);
        }

        // Load the rasterized PNG as a RasterImage, apply Sharpen filter, and save the result
        using (Image rasterImageContainer = Image.Load(tempPngPath))
        {
            var rasterImage = (RasterImage)rasterImageContainer;

            // Apply Sharpen filter with kernel size 5 and sigma 4.0 to the whole image
            rasterImage.Filter(rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the sharpened image
            rasterImage.Save(outputPath, new PngOptions());
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}