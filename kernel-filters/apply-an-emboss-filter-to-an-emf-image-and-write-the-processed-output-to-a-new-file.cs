using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input EMF, temporary raster PNG, and final output PNG
        string inputEmfPath = "input.emf";
        string tempPngPath = "temp.png";
        string outputPngPath = "output.png";

        // Step 1: Load the EMF image and rasterize it to a PNG file
        using (Image emfImage = Image.Load(inputEmfPath))
        {
            // Configure rasterization options for EMF to PNG conversion
            EmfOptions emfOptions = new EmfOptions
            {
                VectorRasterizationOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                }
            };

            // Save the rasterized image as a temporary PNG
            emfImage.Save(tempPngPath, emfOptions);
        }

        // Step 2: Load the rasterized PNG, apply emboss filter, and save the result
        using (Image rasterImage = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)rasterImage;

            // Use the predefined emboss kernel (3x3) from ConvolutionFilter
            double[,] embossKernel = ConvolutionFilter.Emboss3x3;

            // Apply the emboss filter to the entire image
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(embossKernel));

            // Save the processed image as PNG
            raster.Save(outputPngPath, new PngOptions());
        }

        // Optional: clean up the temporary PNG file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}