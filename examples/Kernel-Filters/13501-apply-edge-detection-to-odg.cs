using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input ODG file path
        string inputPath = "input.odg";
        // Output raster image path
        string outputPath = "output.png";

        // Load the ODG vector image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare PNG options with rasterization settings for the vector image
            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = vectorImage.Size
            };

            // Rasterize the vector image into a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                vectorImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    RasterImage raster = (RasterImage)rasterImage;

                    // Define an edge detection kernel
                    double[,] edgeKernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    // Apply the convolution filter with the edge detection kernel
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(edgeKernel));

                    // Save the filtered image
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}