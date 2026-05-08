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

            // List of raster image files to process (add your file names here)
            string[] inputFiles = new[]
            {
                Path.Combine(inputDir, "image1.png"),
                Path.Combine(inputDir, "image2.jpg"),
                Path.Combine(inputDir, "image3.bmp")
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path with .svg extension
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load raster image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 1024x1024
                    image.Resize(1024, 1024);

                    // Apply median filter with size 5
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));
                    }

                    // Save as SVG using vector rasterization options
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };
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