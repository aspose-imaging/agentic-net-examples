using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output_edge.tif";

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access TIFF-specific methods
            TiffImage tiffImage = (TiffImage)image;

            // Define an edge detection kernel
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Create convolution filter options with the kernel
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

            // Apply the edge detection filter to the entire image
            tiffImage.Filter(tiffImage.Bounds, filterOptions);

            // Save the processed image as TIFF using default options
            var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffImage.Save(outputPath, saveOptions);
        }
    }
}