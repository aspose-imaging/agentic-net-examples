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
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // List of PNG files to process (hardcoded)
            string[] files = new[]
            {
                "image1.png",
                "image2.png",
                "image3.png"
            };

            foreach (string fileName in files)
            {
                // Build full paths
                string inputPath = Path.Combine(inputDir, fileName);
                string outputPath = Path.Combine(outputDir, Path.ChangeExtension(fileName, ".svg"));

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Set up SVG rasterization options
                    var vectorOptions = new SvgRasterizationOptions
                    {
                        PageSize = rasterImage.Size
                    };

                    // Save the blurred image as SVG
                    image.Save(outputPath, new SvgOptions { VectorRasterizationOptions = vectorOptions });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}