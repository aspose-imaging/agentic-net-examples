using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
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
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply Emboss filter using predefined kernel
            var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);

            raster.Filter(raster.Bounds, embossOptions);

            // Save the processed image as JPEG
            var jpegOptions = new JpegOptions();
            raster.Save(outputPath, jpegOptions);
        }
    }
}