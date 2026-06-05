using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // List of raster image file names to process
            string[] files = new[]
            {
                "photo1.png",
                "photo2.jpg",
                "photo3.bmp"
            };

            foreach (string fileName in files)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputDir, fileName);
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".svg");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image, apply median filter, and save as SVG
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering functionality
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a median filter with a kernel size of 5 to the entire image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Save the filtered image as SVG using default SVG options
                    rasterImage.Save(outputPath, new SvgOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}