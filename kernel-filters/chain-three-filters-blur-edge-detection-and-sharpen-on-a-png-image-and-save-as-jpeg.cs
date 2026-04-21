using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur filter
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Apply edge detection using a custom convolution kernel (Laplacian)
            double[,] edgeKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(edgeKernel));

            // Apply sharpen filter
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image as JPEG
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90,
                Source = new FileCreateSource(outputPath, false)
            };
            raster.Save(outputPath, jpegOptions);
        }
    }
}