using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input file paths
        string[] inputPaths = new[]
        {
            @"C:\Images\sample1.png",
            @"C:\Images\sample2.jpg",
            @"C:\Images\sample3.bmp"
        };

        // Output directory (hardcoded)
        string outputDir = @"C:\Images\FilteredSvg";

        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply a median filter with size 5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Prepare output SVG path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the filtered image as SVG
                rasterImage.Save(outputPath, new SvgOptions());
            }
        }
    }
}