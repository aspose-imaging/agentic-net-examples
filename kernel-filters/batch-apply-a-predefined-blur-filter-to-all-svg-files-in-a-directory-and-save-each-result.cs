using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputSvgs";
        string outputDirectory = @"C:\OutputSvgs";

        try
        {
            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path (same name with .blur.png extension)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".blur.png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Set up rasterization options to convert SVG to raster
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    // Define PNG save options that use the rasterization settings
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Rasterize SVG into a memory stream
                    using (var rasterStream = new MemoryStream())
                    {
                        svgImage.Save(rasterStream, pngOptions);
                        rasterStream.Position = 0;

                        // Load the rasterized image as a RasterImage
                        using (Image rasterImage = Image.Load(rasterStream))
                        {
                            var raster = (RasterImage)rasterImage;

                            // Apply Gaussian blur filter (radius 5, sigma 4.0) to the whole image
                            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                            // Save the blurred image to the output path
                            raster.Save(outputPath);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}