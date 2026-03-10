using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input CMX file path
        string inputCmxPath = "input.cmx";
        // Temporary rasterized PNG path
        string tempPngPath = "temp.png";
        // Output image path (PNG format)
        string outputPath = "output.png";

        // Load the CMX vector image
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputCmxPath))
        {
            // Rasterize CMX to PNG using vector rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageSize = cmxImage.Size
                }
            };
            cmxImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG as a RasterImage
        using (Image image = Image.Load(tempPngPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Apply emboss filter using convolution kernel
            rasterImage.Filter(
                rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

            // Save the filtered image
            PngOptions saveOptions = new PngOptions();
            rasterImage.Save(outputPath, saveOptions);
        }

        // Optionally delete the temporary PNG file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}