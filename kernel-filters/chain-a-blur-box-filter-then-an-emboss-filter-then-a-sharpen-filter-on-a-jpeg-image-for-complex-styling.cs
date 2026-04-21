using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output/output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply a blur box filter (size 5)
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetBlurBox(5)));

            // Apply an emboss filter
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Apply a sharpen filter (kernel size 5, sigma 4.0)
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image as JPEG
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90
            };
            raster.Save(outputPath, jpegOptions);
        }
    }
}