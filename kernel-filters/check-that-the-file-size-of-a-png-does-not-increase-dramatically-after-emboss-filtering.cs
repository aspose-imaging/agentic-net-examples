using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.png";
        string outputPath = "output\\sample_emboss.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // Apply emboss filter using convolution kernel
            var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
            raster.Filter(raster.Bounds, embossOptions);

            // Prepare PNG save options
            var pngOptions = new PngOptions
            {
                FilterType = PngFilterType.Adaptive,
                PngCompressionLevel = PngCompressionLevel.ZipLevel9
            };

            // Save the filtered image
            raster.Save(outputPath, pngOptions);
        }

        // Compare file sizes
        long originalSize = new FileInfo(inputPath).Length;
        long filteredSize = new FileInfo(outputPath).Length;

        Console.WriteLine($"Original size: {originalSize} bytes");
        Console.WriteLine($"Embossed size: {filteredSize} bytes");

        // Simple check for dramatic increase (e.g., > 50% increase)
        if (filteredSize > originalSize * 1.5)
        {
            Console.WriteLine("Warning: The PNG file size increased significantly after emboss filtering.");
        }
        else
        {
            Console.WriteLine("The PNG file size increase is within acceptable limits.");
        }
    }
}