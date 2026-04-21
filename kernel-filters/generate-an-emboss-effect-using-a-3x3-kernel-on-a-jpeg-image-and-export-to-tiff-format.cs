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
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.tif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir);

        // Load JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Define 3x3 emboss kernel
            double[,] embossKernel = new double[,]
            {
                { -2, -1, 0 },
                { -1,  1, 1 },
                {  0,  1, 2 }
            };

            // Create convolution filter options with the emboss kernel
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);

            // Apply emboss filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Prepare TIFF save options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the processed image as TIFF
            raster.Save(outputPath, tiffOptions);
        }
    }
}