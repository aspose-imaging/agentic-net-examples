using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_soft_focus.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (JpegImage jpegImage = new JpegImage(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)jpegImage;

            // Create a 7x7 Gaussian blur filter (soft focus) with neutral brightness
            // Size = 7 (kernel size), Sigma = 2.0 (controls blur amount)
            // Bias = 0 and Factor = 1.0 keep the overall brightness unchanged
            var blurOptions = new GaussianBlurFilterOptions(7, 2.0)
            {
                Bias = 0,
                Factor = 1.0
            };

            // Apply the filter to the whole image
            rasterImage.Filter(rasterImage.Bounds, blurOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}