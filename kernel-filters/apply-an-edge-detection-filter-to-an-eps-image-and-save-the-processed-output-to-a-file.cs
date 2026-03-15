using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input EPS, temporary raster PNG, and final output
        string epsPath = "input.eps";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load the EPS image
        using (EpsImage epsImage = (EpsImage)Image.Load(epsPath))
        {
            // Prepare rasterization options to convert EPS to PNG
            var rasterOptions = new PngOptions
            {
                VectorRasterizationOptions = new EpsRasterizationOptions
                {
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                }
            };

            // Save EPS as a raster PNG (temporary file)
            epsImage.Save(tempPngPath, rasterOptions);
        }

        // Load the rasterized PNG as a RasterImage
        using (RasterImage rasterImage = (RasterImage)Image.Load(tempPngPath))
        {
            // Define a simple edge detection kernel (Laplacian)
            double[,] edgeKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Create convolution filter options with the kernel
            var convOptions = new ConvolutionFilterOptions(edgeKernel);

            // Apply the edge detection filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, convOptions);

            // Save the processed image to the desired output format (PNG)
            rasterImage.Save(outputPath, new PngOptions());
        }

        // Optionally delete the temporary raster file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}