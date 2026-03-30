using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input URL and output file path
        string inputPath = "https://example.com/sample.jpg";
        string outputPath = "output.png";

        // Verify input path existence (as per safety rules)
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image from the URL
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Create convolution filter options using the 5x5 emboss kernel
            ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5);

            // Apply the emboss filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Prepare PNG save options with a file source
            Source source = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = source };

            // Save the filtered image
            raster.Save(outputPath, pngOptions);
        }
    }
}