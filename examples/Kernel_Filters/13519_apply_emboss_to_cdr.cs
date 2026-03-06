using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input CDR file path
        string inputPath = "input.cdr";
        // Output raster image path
        string outputPath = "output.png";

        // Load the CDR vector image
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Prepare rasterization options for CDR
            CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = cdrImage.Size
            };

            // Rasterize the CDR image to a PNG stored in memory
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PngOptions pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                cdrImage.Save(memoryStream, pngSaveOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    // Apply Emboss filter using a predefined convolution kernel
                    rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Save the filtered raster image
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}