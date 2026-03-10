using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input CDR file path and output raster image path
        string inputCdrPath = "input.cdr";
        string outputPath = "output.png";

        // Load the CDR vector image
        using (var cdrImage = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Image.Load(inputCdrPath))
        {
            // Prepare PNG options with rasterization settings for the CDR image
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new CdrRasterizationOptions()
            };

            // Rasterize the CDR image into a memory stream
            using (var memoryStream = new MemoryStream())
            {
                cdrImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (var rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    // Define a simple edge detection kernel (3x3 Laplacian)
                    double[,] edgeKernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    // Apply the convolution filter using the edge detection kernel
                    var convolutionOptions = new ConvolutionFilterOptions(edgeKernel);
                    rasterImage.Filter(rasterImage.Bounds, convolutionOptions);

                    // Save the filtered raster image
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}