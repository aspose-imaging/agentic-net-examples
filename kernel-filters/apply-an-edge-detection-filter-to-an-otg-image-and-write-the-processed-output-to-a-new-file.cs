using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input OTG, temporary rasterized PNG, and final output
        string inputPath = "input.otg";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load the OTG image and rasterize it to a PNG file
        using (Image otgImage = Image.Load(inputPath))
        {
            // Configure rasterization options to preserve the original size
            OtgRasterizationOptions otgOptions = new OtgRasterizationOptions();
            otgOptions.PageSize = otgImage.Size;

            // Set PNG save options with the vector rasterization options
            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = otgOptions;

            // Save the rasterized image to a temporary PNG file
            otgImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG and apply an edge detection filter (sharpen)
        using (Image image = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply a sharpen filter which emphasizes edges
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image to the final output file
            raster.Save(outputPath, new PngOptions());
        }

        // Clean up the temporary PNG file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}