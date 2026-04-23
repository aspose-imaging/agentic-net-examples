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

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path (same name with .png extension)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Set up rasterization options for SVG
                    SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    // Prepare PNG save options with rasterization
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Rasterize SVG to a memory stream as PNG
                    using (MemoryStream rasterStream = new MemoryStream())
                    {
                        svgImage.Save(rasterStream, pngOptions);
                        rasterStream.Position = 0;

                        // Load the rasterized image as a RasterImage
                        using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                        {
                            // Apply Gaussian blur filter to the entire image
                            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                            // Save the blurred image to the output path
                            rasterImage.Save(outputPath);
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