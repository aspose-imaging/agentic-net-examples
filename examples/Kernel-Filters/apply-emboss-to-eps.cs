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
        // Paths for input EPS, temporary raster PNG, and final output
        string inputEpsPath = "input.eps";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load the EPS image and rasterize it to a temporary PNG
        using (var epsImage = Image.Load(inputEpsPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new EpsRasterizationOptions
                {
                    // Preserve original dimensions
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                }
            };
            epsImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG as a RasterImage
        using (var rasterImage = (RasterImage)Image.Load(tempPngPath))
        {
            // Apply Emboss filter using convolution kernel
            rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

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