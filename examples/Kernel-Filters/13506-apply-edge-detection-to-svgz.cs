using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVGZ file path
        string inputPath = @"C:\Images\input.svgz";
        // Output raster image path (PNG)
        string outputPath = @"C:\Images\output.png";

        // Load the compressed SVGZ image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for SVG
            var rasterOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
            {
                PageSize = vectorImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // Set up PNG save options with the rasterization options
            var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVGZ to PNG in memory
            using (MemoryStream rasterStream = new MemoryStream())
            {
                vectorImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (Image rasterImageContainer = Image.Load(rasterStream))
                {
                    var rasterImage = (RasterImage)rasterImageContainer;

                    // Define a simple edge detection kernel (3x3)
                    double[,] edgeKernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    // Create convolution filter options with the kernel
                    var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel);

                    // Apply the edge detection filter to the entire image
                    rasterImage.Filter(rasterImage.Bounds, convOptions);

                    // Save the filtered image
                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}