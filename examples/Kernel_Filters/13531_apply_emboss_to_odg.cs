using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input ODG file path
        string inputPath = "input.odg";
        // Temporary rasterized PNG path
        string tempPngPath = "temp.png";
        // Output image path after applying emboss filter
        string outputPath = "output.png";

        // Load the ODG vector image and rasterize it to PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Set up rasterization options for ODG
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = vectorImage.Size
            };

            // Configure PNG save options with the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image to a temporary PNG file
            vectorImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply emboss filter, and save the result
        using (Image rasterImage = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)rasterImage;

            // Apply emboss filter using predefined convolution kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the filtered image
            raster.Save(outputPath);
        }

        // Optionally delete the temporary PNG file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}