using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Input EMF file and output PNG file paths
        string inputPath = "input.emf";
        string outputPath = "output.png";

        // Load the EMF image
        using (Image emfImage = Image.Load(inputPath))
        {
            // Obtain default vector rasterization options for the EMF image
            VectorRasterizationOptions vectorOptions = (VectorRasterizationOptions)emfImage.GetDefaultOptions(
                new object[] { Aspose.Imaging.Color.White, emfImage.Width, emfImage.Height });

            // Create a temporary PNG file to rasterize the EMF image
            string tempPngPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");

            // Rasterize EMF to PNG using the vector options
            emfImage.Save(tempPngPath, new PngOptions { VectorRasterizationOptions = vectorOptions });

            // Load the rasterized PNG as a RasterImage
            using (Image rasterImageContainer = Image.Load(tempPngPath))
            {
                RasterImage rasterImage = (RasterImage)rasterImageContainer;

                // Apply emboss filter using a predefined convolution kernel
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Save the processed image to the final output file
                rasterImage.Save(outputPath, new PngOptions());
            }

            // Clean up the temporary raster file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
            }
        }
    }
}