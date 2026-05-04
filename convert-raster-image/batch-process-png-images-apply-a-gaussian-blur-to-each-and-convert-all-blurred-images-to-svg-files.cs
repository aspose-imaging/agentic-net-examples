using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // List of PNG files to process
            string[] inputFiles = new string[]
            {
                Path.Combine(inputDir, "image1.png"),
                Path.Combine(inputDir, "image2.png")
                // Add more file names as needed
            };

            foreach (var inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output SVG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Apply Gaussian blur to the entire image
                    RasterImage rasterImage = (RasterImage)image;
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Set up SVG save options with rasterization settings
                    var vectorOptions = new SvgRasterizationOptions { PageSize = rasterImage.Size };
                    var svgOptions = new SvgOptions { VectorRasterizationOptions = vectorOptions };

                    // Save the blurred image as SVG
                    image.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}